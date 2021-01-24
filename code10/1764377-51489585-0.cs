    private static void SignXml(XmlDocument doc, X509Certificate2 cert)
    {
    	var signer = new SignedXmlWithId(doc);
    
    	signer.SigningKey = cert.PrivateKey;
    	signer.KeyInfo = new KeyInfo();
    
    	var s = new SecurityTokenReference();
    	s.Reference = "uuid-639b0-fc-1";
    	s.ValueType = "http://Something.com";
    	signer.KeyInfo.AddClause(s);
    
    	signer.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigExcC14NTransformUrl;
    	var bodyRef = new Reference("#ID-00008");
    	var messageRef = new Reference("#ID-00004");
    	var usernameRef = new Reference("#ID-00001");
    	
    	bodyRef.AddTransform(new XmlDsigExcC14NTransform());
    	messageRef.AddTransform(new XmlDsigExcC14NTransform());
    	usernameRef.AddTransform(new XmlDsigExcC14NTransform());
    	
    	signer.AddReference(bodyRef);
    	signer.AddReference(messageRef);
    	signer.AddReference(usernameRef);
    	
    	signer.ComputeSignature();
    
    	var signData = signer.GetXml();
    
    	var nsmgr = new XmlNamespaceManager(doc.NameTable);
    	nsmgr.AddNamespace("SOAP-ENV", "http://schemas.xmlsoap.org/soap/envelope/");
    	nsmgr.AddNamespace("wsee", "http://stuff.to.add");
    	nsmgr.AddNamespace("cwsh", "http://more.stuff.to.add");
    
    	var security = doc.SelectSingleNode("/SOAP-ENV:Envelope/SOAP-ENV:Header/wsee:Security", nsmgr);
    	security.AppendChild(doc.ImportNode(signData, true));
    }
    
    //Subclass to add namespace when signing
    public class SignedXmlWithId : SignedXml
    {
    	public SignedXmlWithId(XmlDocument xml) : base(xml)
    	{
    	}
    
    	public SignedXmlWithId(XmlElement xmlElement) : base(xmlElement)
    	{
    	}
    
    	public override XmlElement GetIdElement(XmlDocument doc, string id)
    	{
    		// check to see if it's a standard ID reference
    		var idElem = base.GetIdElement(doc, id);
    
    		if (idElem == null)
    		{
    			var nsManager = new XmlNamespaceManager(doc.NameTable);
    			nsManager.AddNamespace("wsu",
    				"http://wsssecurity.location");
    
    			idElem = doc.SelectSingleNode("//*[@wsu:Id=\"" + id + "\"]", nsManager) as XmlElement;
    		}
    
    		return idElem;
    	}
    }
