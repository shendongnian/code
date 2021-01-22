    // Don't forget to add references to System.ServiceModel and System.ServiceModel.Web
    
    using System.ServiceModel;
    using System.ServiceModel.Configuration;
    
    var port = 1234;
    var isSsl = true;
    var scheme = isSsl ? "https" : "http";
    
    var currAssembly = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
    Configuration config = ConfigurationManager.OpenExeConfiguration(currAssembly);
    
    ServiceModelSectionGroup serviceModel = ServiceModelSectionGroup.GetSectionGroup(config);
    
    // Get the first endpoint in services.  This is my RESTful service.
    var endp = serviceModel.Services.Services[0].Endpoints[0];
    
    // Assign new values for endpoint
    UriBuilder b = new UriBuilder(endp.Address);
    b.Port = port;
    b.Scheme = scheme;
    endp.Address = b.Uri;
    
    // Adjust design time baseaddress endpoint
    var baseAddress = serviceModel.Services.Services[0].Host.BaseAddresses[0].BaseAddress;
    b = new UriBuilder(baseAddress);
    b.Port = port;
    b.Scheme = scheme;
    serviceModel.Services.Services[0].Host.BaseAddresses[0].BaseAddress = b.Uri.ToString();
    
    // Setup the Transport security
    BindingsSection bindings = serviceModel.Bindings;
    WebHttpBindingCollectionElement x =(WebHttpBindingCollectionElement)bindings["webHttpBinding"];
    WebHttpBindingElement y = (WebHttpBindingElement)x.ConfiguredBindings[0];
    var e = y.Security;
    
    e.Mode = isSsl ? WebHttpSecurityMode.Transport : WebHttpSecurityMode.None;
    e.Transport.ClientCredentialType = HttpClientCredentialType.None;
    
    // Save changes
    config.Save();
