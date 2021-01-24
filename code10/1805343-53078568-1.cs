            public class AboutModel : PageModel
            {
                private ILogger _logger;
        
                public AboutModel(ILogger<AboutModel> logger)
                {
                    _logger = logger;
                }
        
                public string Message { get; set; }
        
                public void OnGet()
                {
                    _logger.LogInformation("it is just a test herexxxx");
    
                   //Only this format can log as exception
                    _logger.LogError(new Exception(), "it is a new Exceptionxxxx");
    
                   //it will log as trace
                    _logger.LogError("error logs xxx");
                    Message = "Your application description page.";
                }
            }
