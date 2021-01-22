    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Xml;
    using System.IO;
    using System.Text;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    
    namespace SoapRequestEcho
    {
      [WebService(
      Namespace = "http://soap.request.echo.com/",
      Name = "SoapRequestEcho")]
      public class EchoWebService : WebService
      {
    
        [WebMethod(Description = "Echo Soap Request")]
        public XmlDocument EchoSoapRequest(int input)
        {
          // Initialize soap request XML
          XmlDocument xmlSoapRequest = new XmlDocument();
    
          // Get raw request body
          using (Stream receiveStream = HttpContext.Current.Request.InputStream)
          {
             // Move to begining of input stream and read
             receiveStream.Position = 0;
             using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
             {
               // Load into XML document
               xmlSoapRequest.Load(readStream);
             }
          }
    
          // Return
          return xmlSoapRequest;
        }
      }
    }
