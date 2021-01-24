    public string CreateXml(List<SDKReq> list)
	{
		//first create the xml declaration
		XmlDocument doc = new XmlDocument();
		doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));
		//second create a container node for all SDKReq objects
		XmlNode SdkListNode = doc.CreateElement("SDKReqList");
		doc.AppendChild(SdkListNode);
		//iterate through all SDKReq objects and create a container node for each of it
		foreach (SDKReq item in list)
		{
			XmlNode sdkNode = doc.CreateElement("SDKReq");
			SdkListNode.AppendChild(sdkNode);
			//create a container node for all strings in SDKReq.Identifier
			XmlNode IdListNode = doc.CreateElement("Identifiers");
			sdkNode.AppendChild(IdListNode);
			//iterate through all SDKReq.Identifiers and create a node foreach of it
			foreach (string s in item.Identifier)
			{
				XmlNode idNode = doc.CreateElement("Identifier");
				idNode.InnerText = s;
				IdListNode.AppendChild(idNode);
			}
			//create a container node for all SDKReq.Prop
			XmlNode propListNode = doc.CreateElement("Props");
			sdkNode.AppendChild(propListNode);
			//iterate through all SDKReq.Prop and create a node for each of it
			foreach (KeyValuePair<string, string> kvp in item.Prop)
			{
				//since the SDKReq.Prop is a dictionary, you should add both, key and value, to the node.
				//i decided to add an attribute 'key' for the key
				XmlNode propNode = doc.CreateElement("Prop");
				XmlAttribute attribute = doc.CreateAttribute("key");
				attribute.Value = kvp.Key;
				propNode.Attributes.Append(attribute);
				propNode.InnerText = kvp.Value;
				propListNode.AppendChild(propNode);
			}
		}
		return doc.InnerXml;
	}
