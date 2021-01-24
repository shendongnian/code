    class Program
        {
            static void Main(string[] args)
            {
                ServiceReference2.CalculatorClient client = new ServiceReference2.CalculatorClient();
                try
                {
                    var result = client.Add(34, 20);
                    Console.WriteLine(result);
                }
                catch (Exception)
                {
                    throw;
                }
            }
    
        }
        public class ClientMessageLogger : IClientMessageInspector
        {
            public void AfterReceiveReply(ref Message reply, object correlationState)
            {
                string result = $"server reply message:\n{reply}\n";
                Console.WriteLine(result);
            }
    
            public object BeforeSendRequest(ref Message request, IClientChannel channel)
            {
    
                XmlDocument doc = new XmlDocument();
                MemoryStream ms = new MemoryStream();
                XmlWriter writer = XmlWriter.Create(ms);
                request.WriteMessage(writer);
                writer.Flush();
                ms.Position = 0;
                doc.Load(ms);
    
                ChangeMessage(doc);
    
                ms.SetLength(0);
                writer = XmlWriter.Create(ms);
    
                doc.WriteTo(writer);
                writer.Flush();
                ms.Position = 0;
                XmlReader reader = XmlReader.Create(ms);
                request = System.ServiceModel.Channels.Message.CreateMessage(reader, int.MaxValue, request.Version);
                string result = $"client ready to send message:\n{request}\n";
                Console.WriteLine(result);
                return null;
            }
            void ChangeMessage(XmlDocument doc)
            {
                XmlElement element = (XmlElement)doc.GetElementsByTagName("s:Envelope").Item(0);
                if (element != null)
                {
                    element.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
                    element.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                }
            }
        }
        public class CustContractBehaviorAttribute : Attribute, IContractBehavior, IContractBehaviorAttribute
        {
            public Type TargetContract => typeof(ICalculator);
    
            public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
                return;
            }
    
            public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
                clientRuntime.ClientMessageInspectors.Add(new ClientMessageLogger());
            }
    
            public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
            {
                return;
            }
    
            public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
            {
                return;
            }
    }  
