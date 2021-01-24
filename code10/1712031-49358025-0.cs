     public class Startup {
      public void Configuration(IAppBuilder app) {
       // Add CORS if required 
       //   app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);          
       // Any connection or hub wire up and configuration should go here
       app.MapSignalR();
      }
     }
 
  
