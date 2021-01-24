    [HttpGet("{email}")]
    [Route("UserAppointments/{email}")]
    public IHttpActionResult GetAppoinment(string email = null){
        if (!string.IsNullOrEmpty(email)){
            //Your business logic ...
            List<UserAppointment> app = new List<UserAppointment>();
            if (app.Count() <= 0)
                return Content(HttpStatusCode.NoContent, string.Format("No appointment found for the user [{0}]", email));
            else
                return Ok(app);
        } else {
            return BadRequest("No email provided");
        }
    }
