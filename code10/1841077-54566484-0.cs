    public class Startup
    {
      // This method gets called by the runtime. Use this method to add services to the container.
      // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
      public void ConfigureServices(IServiceCollection services)
      {
      }
      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
        if (env.IsDevelopment())
        {
          app.UseDeveloperExceptionPage();
        }
        app.Run(async (context) =>
        {
          var request = context.Request;
          var body = request.Body;
          request.EnableRewind();
          var buffer = new byte[Convert.ToInt32(request.ContentLength)];
          await request.Body.ReadAsync(buffer, 0, buffer.Length);
          var bodyAsText = Encoding.UTF8.GetString(buffer);
          request.Body = body;
          await context.Response.WriteAsync(bodyAsText);
        });
      }
    }
