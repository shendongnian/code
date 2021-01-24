    public class FormPostConverter : IDispatchMessageInspector
    {
    	public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
    	{
    		var contentType = (request.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty)?.Headers["Content-Type"];
    
    		if (!request.IsEmpty && contentType == "application/x-www-form-urlencoded")
    		{
    			var body = HttpUtility.ParseQueryString(new StreamReader(request.GetBody<Stream>()).ReadToEnd());
    			if (body != null && body.HasKeys())
    			{
    				Message newMessage = Message.CreateMessage(MessageVersion.None, "", new XElement("root", body.AllKeys.Select(o => new XElement(o, body[o]))));
    				newMessage.Headers.CopyHeadersFrom(request);
    				newMessage.Properties.CopyProperties(request.Properties);
    				(newMessage.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty)?.Headers.Set(HttpRequestHeader.ContentType, "application/json");
    				newMessage.Properties[WebBodyFormatMessageProperty.Name] = new WebBodyFormatMessageProperty(WebContentFormat.Json);
    				request = newMessage;
    			}
    		}
    
    		return true;
    	}
    
    	public void BeforeSendReply(ref Message reply, object correlationState)
    	{ }
    }
