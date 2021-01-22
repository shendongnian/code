    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ServiceModel.Activation;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceModel.Web;
    
    namespace WcfJsonServiceToGetImages
    {
        public class Class1 : WebScriptServiceHostFactory
        {
            protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
            {    
                ServiceHost host = new ServiceHost(typeof(Service1),baseAddresses);
               foreach(Uri uri in baseAddresses)
                {       
              WebHttpBinding webbinding=new WebHttpBinding(WebHttpSecurityMode.None);
                webbinding.AllowCookies=true;
                webbinding.CrossDomainScriptAccessEnabled=true;
                EndpointAddress ea=new EndpointAddress(uri);           
                WebScriptEnablingBehavior behavior = new WebScriptEnablingBehavior();
                behavior.DefaultOutgoingResponseFormat = WebMessageFormat.Json;
               // behavior.DefaultBodyStyle = WebMessageBodyStyle.WrappedRequest;      
                
          
                
                behavior.DefaultOutgoingRequestFormat = WebMessageFormat.Json;
               ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(IService1), webbinding, uri);
               endpoint.Behaviors.Add(behavior);         
              }            
                return host;        
            }
        }
    }
