        public static class UserSession
            {
                private static IHttpContextAccessor _accessor;
                public static void Configure(IHttpContextAccessor httpContextAccessor)
                {
                    _accessor = httpContextAccessor;
                }
        
                public static HttpContext HttpContext => _accessor.HttpContext;
        
        
                public static Guid UserId
                {
                    get
                    {
                        if (HttpContext.Session.GetString("UserId") == null || Guid.Parse(HttpContext.Session.GetString("UserId")) == Guid.Empty)
                            return Guid.Empty;
                        else
                            return Guid.Parse(Convert.ToString(HttpContext.Session.GetString("UserId")));
                    }
                    set
                    {
                        HttpContext.Session.SetString("UserId", Convert.ToString(value));
                    }
                }
        
        
                public static byte[] ProfileImage
                {
                    get
                    {
                        if (HttpContext.Session.GetObject<byte[]>("ProfileImage") == null)
                            return null;
                        else
                            return HttpContext.Session.GetObject<byte[]>("ProfileImage");
                    }
                    set
                    {
                        HttpContext.Session.SetObject("ProfileImage", value);
                    }
                }
        
                public static string JwtToken
                {
                    get
                    {
                        if (HttpContext.Session.GetString("JwtToken") == null)
                            return null;
                        else
                            return HttpContext.Session.GetString("JwtToken");
                    }
                    set
                    {
                        HttpContext.Session.SetString("JwtToken", value);
                    }
                }
        
                public static string FirstName
                {
                    get
                    {
                        if (HttpContext.Session.GetString("FirstName") == null)
                            return null;
                        else
                            return HttpContext.Session.GetString("FirstName");
                    }
                    set
                    {
                        HttpContext.Session.SetString("FirstName", value);
                    }
                }
        
                public static string LastName
                {
                    get
                    {
                        if (HttpContext.Session.GetString("LastName") == null)
                            return null;
                        else
                            return HttpContext.Session.GetString("LastName");
                    }
                    set
                    {
                        HttpContext.Session.SetString("LastName", value);
                    }
                }
        
                public static string FullName { get { return (!string.IsNullOrWhiteSpace(FirstName) ? FirstName : string.Empty) + " " + (!string.IsNullOrWhiteSpace(LastName) ? LastName : string.Empty); } }
        
        
                public static string Email
                {
                    get
                    {
                        if (HttpContext.Session.GetString("Email") == null)
                            return null;
                        else
                            return HttpContext.Session.GetString("Email");
                    }
                    set
                    {
                        HttpContext.Session.SetString("Email", value);
                    }
                }
            }
