    [HttpPost]
    public async Task<IActionResult> RemoveFromCart(int id)
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
        }
    
        var antiForgery = Context.RequestServices.GetService<AntiForgery>();
        result = antiForgery.Validate(Context, new AntiForgeryTokenSet(formToken, cookieToken))
