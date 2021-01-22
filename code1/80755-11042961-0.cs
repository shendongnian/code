    [OperationBehavior(Impersonation = ImpersonationOption.Allowed)]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare, 
            RequestFormat = WebMessageFormat.Json
            )]
    public Stream getJsonRequest()
        {
    
            // Get the raw json POST content.  .Net has this in XML string..
            string JSONstring = OperationContext.Current.RequestContext.RequestMessage.ToString();
            // Parse the XML string into a XML document
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(JSONstring);
			
			foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
					node.Name // has key
                    node.InnerText;  // has value
