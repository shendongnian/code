			var xml = new XElement("root",
								   new XElement("node",
												new XAttribute("index", 1)
									),
								   new XElement("node",
												new XAttribute("index", 2)
									),
								   new XElement("node",
												new XAttribute("index", 3)
									),
								   new XElement("node",
												new XAttribute("index", 4)
									)
				);
			IEnumerable<XElement> ieXml =
				from XElement e in xml.Elements()
				select e;
			var outXml = new XElement("root");
			foreach (var item in ieXml)
			{
				item.Add(new XElement(
					 "Directory",
					 new XAttribute("new", 1)));
				outXml.Add(item);
			}
			outXml.Save(@"d:\foo.xml", SaveOptions.None);
