    @page "/home"
    @page "/home/{username}"
    
    <h1>@Username is authenticated!</h1>
    
    @functions {
    	// Define a property to contain the parameter passed from the auth page
        [Parameter]
        private string Username { get; set; };
    }
     * Do this in your auth.cshtml   
           
        
         @functions{
            
                public string Username { get; set; }
                public string url = "/home";
            
                public async Task AuthAsync()
                {
                    var ticket=await this.auth.AuthenticateAsync(Username);
            		// Attach the parameter to the url
                    urihelper.NavigateTo(url + "/" + Username); 
                }
            }
    
