        Best way to manage Session (globally) in ASP.NET Core is :
        
        
        1). Add  Static Class SessionExtensions.cs
        
          public static class SessionExtensions
            {
                public static void SetObject(this ISession session, string key, object value)
                {
                    session.SetString(key, JsonConvert.SerializeObject(value));
                }
        
                public static T GetObject<T>(this ISession session, string key)
                {
                    var value = session.GetString(key);
                    return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
                }
        
                public static void SetBoolean(this ISession session, string key, bool value)
                {
                    session.Set(key, BitConverter.GetBytes(value));
                }
        
                public static bool? GetBoolean(this ISession session, string key)
                {
                    var data = session.Get(key);
                    if (data == null)
                    {
                        return null;
                    }
                    return BitConverter.ToBoolean(data, 0);
                }
        
                public static void SetDouble(this ISession session, string key, double value)
                {
                    session.Set(key, BitConverter.GetBytes(value));
                }
        
                public static double? GetDouble(this ISession session, string key)
                {
                    var data = session.Get(key);
                    if (data == null)
                    {
                        return null;
                    }
                    return BitConverter.ToDouble(data, 0);
                }
            }
        
        ---------
        
        2). Add Static class UserSession.cs
        Example :
        
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
        ---------
        3).Add this in startup.cs 
         public void ConfigureServices(IServiceCollection services)
        {
         services.AddSession(options =>
                    {
                        options.IdleTimeout = TimeSpan.FromMinutes(60);//You can set Time   
                    });
        			
        		services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        	app.UseSession();
          
        	UserSession.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
        }
        
        4). Voila. Done
    --------------------
    How to use :
    Set session (Ex:Set session for UserId) > UserSession.UserId = 1;
    Get session (int id = UserSession.UserId)
