    using System;
    using System.ServiceModel;
    using Microsoft.Samples.XmlRpc;
    namespace ConsoleApplication2
    {
        // describe your service's interface here
        [ServiceContract]
        public interface IServiceContract
        {
            [OperationContract(Action="Echo")]
            string Hello(string name);
        }
        class Program
        {
            static void Main(string[] args)
            {
                // obviously, change uri to your service
                string serviceUri = "http://www.example.com/xmlrpc";
                
                ChannelFactory<IServiceContract> cf = new ChannelFactory<IServiceContract>(
                    new WebHttpBinding(), serviceUri);
                
                cf.Endpoint.Behaviors.Add(new XmlRpcEndpointBehavior());
                
                IServiceContract client = cf.CreateChannel();
                
                Console.WriteLine(client.Hello("World"));
                Console.ReadKey();
            }
        }
    }
