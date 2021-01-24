    @page "/"
    
    @using Microsoft.AspNetCore.Http
    @using Helpers;
    @using Microsoft.JSInterop;
    
    
    @inject SessionState session
    @inject IJSRuntime JSRuntime
    @code{
           
        public string Username { get; set; }
        public string Password { get; set; }
    }
    
    @functions {
        private async Task SignIn()
        {
            if (!session.Items.ContainsKey("Username") && !session.Items.ContainsKey("Password"))
            {
                //Add to the Singleton scoped Item
                session.Items.Add("Username", Username);
                session.Items.Add("Password", Password);
    //Redirect to homepage
                await JSRuntime.InvokeAsync<string>(
                "clientJsMethods.RedirectTo", "/home");
            }
        }
    }
    
    <div class="col-md-12">
        <h1 class="h3 mb-3 font-weight-normal">Please Sign In</h1>
    </div>
    
    <div class="col-md-12 form-group">
    	<input type="text" @bind="Username" class="form-control" id="username"
    		   placeholder="Enter UserName" title="Enter UserName" />
    </div>
    
    <div class="col-md-12 form-group">
            <input type="password" @bind="Password" class="form-control" id="password"
                   placeholder="Enter Password" title="Enter Password" />
    </div>
    
    
    <button @onclick="SignIn">Login</button>
