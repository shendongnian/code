        [HttpPost]
        public async Task<IActionResult> Method(int id)
        {
        var formParameters = await Context.Request.ReadFormAsync();
        var requestVerification = formParameters["RequestVerificationToken"];
        string cookieToken = null;
        string formToken = null;
        
            if (!string.IsNullOrWhiteSpace(requestVerification))
            {
            var tokens = requestVerification.Split(':');
        
            if (tokens != null && tokens.Length == 2)
            {
                cookieToken = tokens[0];
                formToken = tokens[1];
            }
            
        
            var antiForgery = Context.RequestServices.GetService<AntiForgery>();
            try
            {
                antiForgery.Validate(Context, new AntiForgeryTokenSet(formToken, cookieToken))}
            catch
            {
               //log
            }
    }
