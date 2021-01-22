    using System;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                string addressHttps = String.Format("https://{0}:9010", Dns.GetHostEntry("").HostName);
                var wsHttpBinding = new BasicHttpBinding();
                wsHttpBinding.Security.Mode = BasicHttpSecurityMode.Transport;
                wsHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                var serviceHost = new ServiceHost(typeof (HelloWorldService), new Uri(addressHttps));
                Type endpoint = typeof (IHelloWorldService);
                serviceHost.AddServiceEndpoint(endpoint, wsHttpBinding, "hello");
                serviceHost.Credentials.ServiceCertificate.SetCertificate(
                    StoreLocation.LocalMachine,
                    StoreName.My,
                    X509FindType.FindBySubjectName, "sergiiz2");
                var smb = new ServiceMetadataBehavior();
                smb.HttpsGetEnabled = true;
                smb.HttpsGetUrl = new Uri(serviceHost.Description.Endpoints[0].ListenUri.AbsoluteUri + "/mex");
                serviceHost.Description.Behaviors.Add(smb);
                Console.Out.WriteLine(smb.HttpsGetUrl);
                try
                {
                    serviceHost.Open();
    
                    string address = serviceHost.Description.Endpoints[0].ListenUri.AbsoluteUri;
                    Console.WriteLine("Listening @ {0}", address);
                    Console.WriteLine("Press enter to close the service");
                    Console.ReadLine();
                    serviceHost.Close();
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine("A commmunication error occurred: {0}", ce.Message);
                    Console.WriteLine();
                }
                catch (Exception exc)
                {
                    Console.WriteLine("An unforseen error occurred: {0}", exc.Message);
                    Console.ReadLine();
                }
            }
        }
    
        [ServiceContract]
        public interface IHelloWorldService
        {
            [OperationContract]
            string SayHello(string name);
        }
    
        public class HelloWorldService : IHelloWorldService
        {
            #region IHelloWorldService Members
    
            public string SayHello(string name)
            {
                return string.Format("Hello, {0}", name);
            }
    
            #endregion
        }
    }
