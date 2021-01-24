    protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
            {
                var serviceInstanceListers = new List<ServiceInstanceListener>()
                {
                    new ServiceInstanceListener(context =>
                    {
                        //return CreateRestListener(context);
                        return CreateSoapHTTPSListener(context);
                    }),
                };
                return serviceInstanceListers;
            }
    
            private static ICommunicationListener CreateSoapHTTPSListener(StatelessServiceContext context)
            {
                var binding = new CustomBinding();
                AsymmetricSecurityBindingElement assbe = (AsymmetricSecurityBindingElement)SecurityBindingElement.CreateMutualCertificateBindingElement(
                               MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10);
    
                binding.Elements.Add(assbe);
                binding.Elements.Add(new TextMessageEncodingBindingElement());
                binding.Elements.Add(new HttpsTransportBindingElement());
                // Extract the STS certificate from the certificate store.
                X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindByThumbprint, ConfigurationManager.AppSettings.Get("ClientCertificateThumbprint"), false);
                store.Close();
                var identity = EndpointIdentity.CreateX509CertificateIdentity(certs[0]);
                string uri = ConfigurationManager.AppSettings.Get("ServiceUri");
    
                var listener = new WcfCommunicationListener<IService>(
                    serviceContext: context,
                    wcfServiceObject: new Service(),//where service implements IService
                    listenerBinding: binding,
                    address: new EndpointAddress(new Uri(uri), identity)
                );
    
                listener.ServiceHost.Credentials.ClientCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByThumbprint, ConfigurationManager.AppSettings.Get("ServiceCertificateThumbprint"));
                listener.ServiceHost.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByThumbprint, ConfigurationManager.AppSettings.Get("ClientCertificateThumbprint"));
                
                // Check to see if the service host already has a ServiceMetadataBehavior
                ServiceMetadataBehavior smb = listener.ServiceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
                // If not, add one
                if (smb == null)
                {
                    smb = new ServiceMetadataBehavior();
                    smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy12;
                    smb.HttpsGetEnabled = true;
                    smb.HttpGetEnabled = false;
                    smb.HttpsGetUrl = new Uri(uri);
                    listener.ServiceHost.Description.Behaviors.Add(smb);
                }
                return listener;
            }
