    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
                //here you read all the params
                var data = await context.Request.ReadFormAsync();
                //here you get the param you want
                var param = data.Where(x => x.Key == "CustomParam").Select(x => x.Value).FirstOrDefault();
                string customer = "";
                if (param != null && param.Length > 0)
                {
                    customer = param[0];
                }
    
    }
