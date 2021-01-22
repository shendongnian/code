    using System;
    using System.ServiceModel;
    using Microsoft.Samples.XmlRpc;
    namespace ConsoleApplication1
    {
        // describe your service's interface here
        [ServiceContract]
        public interface IServiceContract
        {
            [OperationContract(Action="Hello")]
            string Hello(string name);
        }
        class Program
        {
            static void Main(string[] args)
            {
                ChannelFactory<IServiceContract> cf = new ChannelFactory<IServiceContract>(
                    new WebHttpBinding(), "http://www.example.com/xmlrpc");
                
                cf.Endpoint.Behaviors.Add(new XmlRpcEndpointBehavior());
                
                IServiceContract client = cf.CreateChannel();
                
                // you can now call methods from your remote service
                string answer = client.Hello("World");
            }
        }
    }
