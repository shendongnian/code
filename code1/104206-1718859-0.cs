            [OperationContract]
            [WebInvoke(Method = "POST", UriTemplate = "Login", BodyStyle = WebMessageBodyStyle.Bare)]
            [AspNetCompatibilityRequirements(RequirementsMode = 
                        AspNetCompatibilityRequirementsMode.Required)]
            public Stream Login(Stream input)
            {
                string username = String.Empty;
                string password = String.Empty;
            
                StreamReader sr = new StreamReader(input);
                string strInput = sr.ReadToEnd();
                sr.Dispose();
            
                // Help needed here:
                usermame = HttpContext.Current.Request.Headers["username"];
                password = HttpContext.Current.Request.Headers["password"];
            
                // blah blah blah return login XML response as a Stream
            }
