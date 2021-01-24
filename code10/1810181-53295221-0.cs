    public class Request
        {
            public string UserName {   get; private set; }
    
            public string Password {  get; private set; }
    
            public string Token { get; private set; }
    
            
            private Request(){
    
               
    
    
            }
    
            public class Builder
            {
    
                private Request request = new Request();
    
                public Builder UserName(string username)
                {
                    request.UserName = username;
                    return this;
    
                }
    
                public Builder Password(string password)
                {
                    request.Password = password;
                    return this;
    
                }
    
                public Builder Token(string token)
                {
                    request.Token = token;
                    return this;
    
                }
    
               
                public Request Build()
                {
    
                    return request;
                }
    
    
            }
        }
