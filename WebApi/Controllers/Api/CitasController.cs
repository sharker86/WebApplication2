﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers.Api
{
    public class CitasController : ApiController
    {
        // GET api/citas
        private CitasContext _context;

        public CitasController()
        {
            _context = new CitasContext();
        }

        //Todas las citas
        public IEnumerable<Cita> Get()
        {
            return _context.Citas.OrderBy(d => d.FechaCita);
        }
        //Cita con identificador = id
        // GET api/citas/5
        public Cita Get(int id)
        {
            return _context.Citas.FirstOrDefault(d=>d.Id==id);
        }

        public HttpResponseMessage Post(Cita cita)
        {
            try
            {
                _context.Citas.Add(cita);
                _context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, true);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        // DELETE api/citas/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var cita = _context.Citas.FirstOrDefault(d => d.Id == id);
                _context.Citas.Remove(cita);
                _context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, true);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
