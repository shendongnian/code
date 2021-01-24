    private static Message CreateError(string message)
    {
        var fault = Message.CreateMessage(MessageVersion.None, "", new TextBodyWriter(message));
        fault.Properties.Add(WebBodyFormatMessageProperty.Name, new WebBodyFormatMessageProperty(WebContentFormat.Raw));
        return fault;
    }
    
    // source: https://www.codeproject.com/Articles/34632/How-to-Pass-Arbitrary-Data-in-a-Message-Object-usi
    public class TextBodyWriter : BodyWriter
    {
        byte[] messageBytes;
    
        public TextBodyWriter(string message)
            : base(true)
        {
            this.messageBytes = Encoding.UTF8.GetBytes(message);
        }
    
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("Binary");
            writer.WriteBase64(this.messageBytes, 0, this.messageBytes.Length);
            writer.WriteEndElement();
        }
    }
