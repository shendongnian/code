    [HttpGet]
    [Route("UserAppointments/{email}")]
    public IHttpActionResult UserAppointments(string email = null) {
        HttpResponseMessage retObject = null;    
        if (!string.IsNullOrEmpty(email)) {
            UserAppointmentService _appservice = new UserAppointmentService();
            IEnumerable<Entities.UserAppointments> app = _appservice.GetAppointmentsByEmail(email);
    
            if (app.Count() <= 0) {
                var message = string.Format("No appointment found for the user [{0}]", email);
                HttpError err = new HttpError(message);
                retObject = Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, err);
                retObject.ReasonPhrase = message;
            } else {
                retObject = Request.CreateResponse(System.Net.HttpStatusCode.OK, app);
            }
        } else {
            var message = string.Format("No email provided");
            HttpError err = new HttpError(message);
            retObject = Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, err);
            retObject.ReasonPhrase = message;
    
        }
        return ResponseMessage(retObject);
    }
