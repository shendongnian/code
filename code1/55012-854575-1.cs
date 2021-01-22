    public static XmlNode FindChildNode(XmlNode parent, string name, System.Collections.Hashtable keyvaluecollection)
		{
			if (parent.NodeType != XmlNodeType.Element) return null;
			XmlElement el = (XmlElement)parent;
			XmlNodeList nodes = el.GetElementsByTagName(name);
			foreach (XmlNode node in nodes)
			{
				if (node.NodeType == XmlNodeType.Element)
				{
					bool found = false;
					foreach (string key in keyvaluecollection.Keys)
					{
						if (node.Attributes[key] != null && node.Attributes[key].Value == (string)keyvaluecollection[key])
						{
							found = true;
						}
						else
						{
							found = false;
							break;
						}
					}
					if (found) return node;
				}
			}
			return null;
		}
