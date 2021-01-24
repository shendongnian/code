    static void Main(string[] args)
        {
            ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();
            try
            {
                var result = client.comunicarAreaContencaoResponse("Hello","World");
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
            
            // Read reply payload 
            XmlDocument doc = new XmlDocument();
            MemoryStream ms = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(ms);
            request.WriteMessage(writer);
            writer.Flush();
            ms.Position = 0;
            doc.Load(ms);
            // Change Body logic 
            ChangeMessage(doc);
            // Write the reply payload 
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
            XmlElement element = (XmlElement)doc.GetElementsByTagName("comunicarAreaContencaoResponse").Item(0);
            if (element!=null)
            {
                element.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
                element.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                element.Attributes.RemoveNamedItem("xmlns:i");
            }
        }
    }
    public class CustContractBehaviorAttribute : Attribute, IContractBehavior, IContractBehaviorAttribute
    {
        public Type TargetContract => typeof(IService);
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
