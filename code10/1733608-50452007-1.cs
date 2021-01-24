	public class SigKillXmlDsigExcC14NTransform : XmlDsigExcC14NTransform
	{
		public SigKillXmlDsigExcC14NTransform() { }
		public override void LoadInput(Object obj)
		{
			XmlElement root = ((XmlDocument)obj).DocumentElement;
			NameTable nt = new NameTable();
			XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
			nsmgr.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");
			XmlNodeList childSignatures = root.SelectNodes("./ds:Signature", nsmgr);
			// Sometimes C# fails to remove the child node.  Let's hold his hand and do it for him.
			foreach (XmlNode oneChild in childSignatures)
			{
				oneChild.ParentNode.RemoveChild(oneChild);
			}
			base.LoadInput(obj);
		}
	}
