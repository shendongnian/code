    public class MyController : ApiController 
    {
        public IActionResult Get()
        {
            // other code...
            HttpResponseMessage result = await client.SendAync(request);
            if (result.StatusCode != HttpStatusCode.OK)
            {
                IActionResult response = ResponseMessage(result);
                return response;
            }
            // other code...
        }    
    }
