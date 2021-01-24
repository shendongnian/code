    // startup.cs
    public static HttpMessageHandler Handler { get; set; }
    // snip from configureservices
    .AddJwtBearer(jwt =>
     {
          // defaults as they were
          jwt.Authority = "http://localhost:5000/";
          jwt.RequireHttpsMetadata = false;
          jwt.Audience = "api1";
          // if static handler is null don't change anything, otherwise assume integration test.
          if(Handler == null)
          {
              jwt.BackchannelHttpHandler = Handler;
              jwt.Authority = "http://localhost/";
          }
      });
