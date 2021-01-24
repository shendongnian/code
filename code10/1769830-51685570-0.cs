    public class FromHeader : MessageHeader    {     
        public override string Name => "ns:From";
        public override string Namespace => "";
        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {                       
            writer.WriteStartElement("ns:Address");
            writer.WriteString("###");
            writer.WriteEndElement();
        }
    }
    using (new OperationContextScope(client.InnerChannel))
    {
    OperationContext.Current.OutgoingMessageHeaders.Add( new FromHeader() );                
    }
