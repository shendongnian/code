    public IHttpActionResult UserAppointments(string email = null)
    {
        if (!string.IsNullOrEmpty(email))
        {
            //Your business logic ...
            List<UserAppointment> app = new List<UserAppointment>();
            app.Add(new UserAppointment());
    
            if (app.Count() <= 0)
            {
                //Change HttpStatusCode and response based on your scenario
                string message = string.Format("No appointment found for the user [{0}]", email);
                return Content(HttpStatusCode.NoContent, message);
            }
            else
            {
                return Ok(app);
            }
        }
        else
        {
            return Content(HttpStatusCode.BadRequest, "No email provided");
        }
    }
