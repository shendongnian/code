    <%@ ServiceHost Language="C#" Debug="true" Service="Sample.RestService.Service" Factory="Sample.RestService.AppServiceHostFactory"%>
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using Microsoft.ServiceModel.Web.SpecializedServices;
    namespace Sample.RestService 
    {
      class AppServiceHostFactory : ServiceHostFactory
      {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            /// ***** The exception occurs on the next line *****
            return new SingletonServiceHost(serviceType, baseAddresses);
        }
      }
    }
