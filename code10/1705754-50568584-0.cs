    // The inspector class has to implement both IClientMessageInspector and IEndpointBehavior interfaces
    public class BFMInspector : IClientMessageInspector, IEndpointBehavior
    {
        // This is the method to action after receiving a response from Sabre
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            try
            {
                // Get compressed response from reply and load that into a byte array.
                XmlDictionaryReader bodyReader = reply.GetReaderAtBodyContents();
                bodyReader.ReadStartElement("CompressedResponse");
                byte[] bodyByteArray = bodyReader.ReadContentAsBase64();
    
                // Create some helper variables
                StringBuilder uncompressed = new StringBuilder();
                String xmlString = "";
                XmlDocument xmlPayload = new XmlDocument();
    
                // Load the byte array into memory
                using (MemoryStream memoryStream = new MemoryStream(bodyByteArray))
                {
                    // Unzip the Stream
                    using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        byte[] buffer = new byte[1024];
                        int readBytes;
    
                        // Unzips character by character
                        while ((readBytes = gZipStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            for (int i = 0; i < readBytes; i++)
                                // Append all characters to build the response
                                uncompressed.Append((char)buffer[i]);
                        }
                    }
    
                    xmlString = uncompressed.ToString();
                    xmlString = xmlString.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>", "");
                }
    
                // Convert the string into an XML
                xmlPayload.LoadXml(xmlString);
    
                // Create a new Message, which is what will substitute what was returned by Sabre
                Message tempMessage = Message.CreateMessage(reply.Version, null, xmlPayload.ChildNodes[0]);
    
                tempMessage.Headers.CopyHeadersFrom(reply.Headers);
                tempMessage.Properties.CopyProperties(reply.Properties);
    
                MessageBuffer bufferOfFault = tempMessage.CreateBufferedCopy(Int32.MaxValue);
    
                // Replace the reply with the new Message
                reply = bufferOfFault.CreateMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            // Nothing is done here, so we simply return null
            return null;
        }
    
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            // Nothing done
        }
    
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            // Add "this" as an endpoint to be inspected
            clientRuntime.MessageInspectors.Add(this);
        }
    
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            // Nothing done
        }
    
        public void Validate(ServiceEndpoint endpoint)
        {
            // Nothing done
        }
    }
