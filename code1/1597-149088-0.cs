XmlDocument doc = new XmlDocument();
doc.LoadXml(xmlWithBogusNamespace);            
XmlNamespaceManager nSpace = new XmlNamespaceManager(doc.NameTable);
nSpace.AddNamespace("myNs", "http://theirUri");
XmlNodeList nodes = doc.SelectNodes("//myNs:NodesIWant",nSpace);
//etc
