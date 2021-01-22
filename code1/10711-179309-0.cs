     XDocument doc = XDocument.Load(@"c:\temp\test.xml");
     XElement demoNode = new XElement("Demographic");
     demoNode.Add(new XElement("Age"));
     demoNode.Add(new XElement("DOB"));
     doc.Descendants("Employee").Single().Add(demoNode);
     doc.Save(@"c:\temp\test2.xml");
