      public async Task<IActionResult>MyAction(string returnUrl)
        {
            if(everything is alright)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return false;
            }
            
        }
