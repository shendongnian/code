    using System;
    using System.IO;
    using System.Web;
    using System.Web.Services.Configuration;
    
    namespace DemoWebService
    {
     public class CustomWsdlModule :
      IHttpModule
     {
      public void
      Init(HttpApplication application)
      {
       // hook up to BeginRequest event on application object
       application.BeginRequest += new EventHandler(this.onApplicationBeginRequest);
      }
    
      public void
      Dispose()
      {
      }
    
      private void
      onApplicationBeginRequest(object source, EventArgs ea)
      {
       HttpApplication application = (HttpApplication)source;
       HttpRequest request = application.Request;
       HttpResponse response = application.Response;
    
       // check if request is for WSDL file
       if ( request.Url.PathAndQuery.EndsWith(".asmx?wsdl", StringComparison.InvariantCultureIgnoreCase) )
       {
        // if Documentation protocol is not allowed, throw exception
        if ( (WebServicesSection.Current.EnabledProtocols & WebServiceProtocols.Documentation) == 0 )
        {
         throw new System.InvalidOperationException("Request format is unrecognized.");
        }
       
        // get path to physical .asmx file
        String asmxPath = request.MapPath(request.Url.AbsolutePath);
        
        // build path to .wsdl file; should be same as .asmx file, but with .wsdl extension
        String wsdlPath = Path.ChangeExtension(asmxPath, ".wsdl");
        
        // check if WSDL file exists
        if ( File.Exists(wsdlPath) )
        {
         // read WSDL file
         using ( StreamReader reader = new StreamReader(wsdlPath) )
         {
          string wsdlFileContents = reader.ReadToEnd();
          
          // write WSDL to response and end response without normal processing
          response.ContentType = "text/xml";
          response.Write(wsdlFileContents);
          response.End();
         }
        }
       }
      }
     }
    }
