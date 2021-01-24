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
