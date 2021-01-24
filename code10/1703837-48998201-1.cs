         //new policy makes [Authorize] availible by claims
              
      services.AddAuthorization((options) => {
                    options.AddPolicy("MyNewPolicy", policybuilder =>
                    {               
                        policybuilder.RequireAuthenticatedUser();
                        policybuilder.RequireClaim("role", "someClaim");
    
                    });
                });
    
    //usage
    
            [Authorize(Roles = "someClaim")]
            public async Task<IActionResult> About(){
    
    
    }
    //to awnsr your comment add a list of claims to your user class ex:
    
       new TestUser
                    {
                        SubjectId="1001",
                        Username="Frank",
                        Password="password",
                        
                        Claims= new List<Claim>
                        {
                            new Claim("given_name","Frank"),
                            new Claim("family_name","Underwood"),
                            new Claim("address","1 addy rd unit 233"),                
                            new Claim("role", "someClaim")
    
    
                        }
    
                    }
