    public partial class SampleService
	{
		public string MessageID { get; set; }
		protected override System.Xml.XmlWriter GetWriterForMessage(System.Web.Services.Protocols.SoapClientMessage message, int bufferSize)
		{
			message.Headers.Add(new UsernameSoapHeader("Username"));
			message.Headers.Add(new PasswordSoapHeader("Password"));
			message.Headers.Add(new MessageIDSoapHeader(MessageID));
			return base.GetWriterForMessage(message, bufferSize);
		}
	}
