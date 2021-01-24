    namespace Facebook.Function
    {
        public class AddLeadWebhook
        {    
            [FunctionName("AddLeadWebhook")]
            public async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
                HttpRequest req,
                ILogger log)
            {
                this.log = log;
                log.LogInformation("C# HTTP trigger function processed a request.");
    
                //Facebook challenge (facebook test webhook)
                if (!string.IsNullOrEmpty(req.Query["hub.challenge"]))
                {
                    log.LogInformation("Facebook challenged");
                    return new OkObjectResult(req.Query["hub.challenge"].FirstOrDefault());
                }
    
                TODO process request
                ...
    
                return new OkResult();
            }
        }
    }
