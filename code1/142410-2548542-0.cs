    public static void SignDocument(XmlDocument xmldoc)
    {
        //Get the XML content from the embedded XML privatekey.
        Stream s = null;
        string xmlkey = string.Empty;
        try
        {
        	s = typeof(Sign).Assembly.GetManifestResourceStream("Licensing.Private.Private.xml");
        
        	// Read-in the XML content.
        	StreamReader reader = new StreamReader(s);
        	xmlkey = reader.ReadToEnd();
        	reader.Close();
        }
        catch (Exception e)
        {
        	throw new Exception("Error: could not import key:",e);
        }
        
        // Create an RSA crypto service provider from the embedded
        // XML document resource (the private key).
        RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
        csp.FromXmlString(xmlkey);
        //Creating the XML signing object.
        SignedXml sxml = new SignedXml(xmldoc);
        sxml.SigningKey = csp;
        
        //Set the canonicalization method for the document.
        sxml.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigCanonicalizationUrl; // No comments.
        
        //Create an empty reference (not enveloped) for the XPath transformation.
        Reference r = new Reference("");
        
        //Create the XPath transform and add it to the reference list.
        r.AddTransform(new XmlDsigEnvelopedSignatureTransform(false));
        
        //Add the reference to the SignedXml object.
        sxml.AddReference(r);
        
        //Compute the signature.
        sxml.ComputeSignature();
        
        // Get the signature XML and add it to the document element.
        XmlElement sig = sxml.GetXml();
        xmldoc.DocumentElement.AppendChild(sig);
    }
