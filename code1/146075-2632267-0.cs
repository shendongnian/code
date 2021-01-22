            public void AddEntry(string title, string story)
            {
                var newElement = new XElement("article", new XElement("title", title), new XElement("story", story));                
                XDocument doc = XDocument.Parse(testXml);
                var maxId = doc.Descendants("article").Attributes("id").Max(x => int.Parse(x.Value));
                newElement.Add(new XAttribute("id", ++maxId));
                doc.Descendants("news").First().Add(newElement);
                //save the document
            }
            public void DeleteEntry(int selectIndex)
            {
                XDocument doc = XDocument.Parse(testXml);
                doc.Descendants("article").Where(x => int.Parse(x.Attribute("id").Value) == selectIndex).Remove();
                //save the document
            }
