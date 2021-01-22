            [OperationContract]
            [WebInvoke(Method = "POST", 
                        UriTemplate = "Login", 
                        BodyStyle = WebMessageBodyStyle.Bare)]
            [AspNetCompatibilityRequirements(RequirementsMode = 
                        AspNetCompatibilityRequirementsMode.Required)]
            public Stream Login(Stream input)
            {
                string username = HttpContext.Current.Request.Params["username"];
                string password = HttpContext.Current.Request.Params["password"];
            }
