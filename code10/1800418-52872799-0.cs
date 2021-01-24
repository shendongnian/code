        System.Xml.XmlNode inputs = xmlDocument.SelectSingleNode("/Sequence/Inputs");
		foreach (System.Xml.XmlNode child in inputs.ChildNodes)
		{
			if (child.InnerText == "readOF")
			{
				String commentContents = child.OuterXml;
				System.Xml.XmlComment commentNode = xmlDocument.CreateComment(commentContents);
				inputs.RemoveChild(child);
				inputs.PrependChild(commentNode);				
				break;
			}
		}
