     public class TrainController : ApiController
    {
        public IHttpActionResult SomeAction()
        {
            HttpResponseMessage responseMsg =
                new 
                HttpResponseMessage(HttpStatusCode.RedirectMethod);
           
            /*responseMsg = your implementation*/
            IHttpActionResult response = this.ResponseMessage(responseMsg);
            return response;
        }
    }
