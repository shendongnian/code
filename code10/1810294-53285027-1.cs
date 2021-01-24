            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(reader.NameTable);
                nsmanager.AddNamespace("ns2", "http://www.zadrwan.com/services/");
                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case "ns2:Response":
                            Console.WriteLine(reader.Name);
                            Console.WriteLine(reader.ReadInnerXml());
                            break;
                    }
                }
            }
