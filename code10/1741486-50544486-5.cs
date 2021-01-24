    [HttpGet]
    [Route("UserAppointments/{email}")]
    public IHttpActionResult UserAppointments(string email = null) {
        if (!string.IsNullOrEmpty(email)) {
            var _appservice = new UserAppointmentService();
            IEnumerable<Entities.UserAppointments> app = _appservice.GetAppointmentsByEmail(email);
            if (app.Count() <= 0) {
                var message = string.Format("No appointment found for the user [{0}]", email);
                return Content(HttpStatusCode.NotFound, message);
            }
            return Ok(app);
        }
        return BadRequest("No email provided");
    }
