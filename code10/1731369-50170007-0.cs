                var reader = XmlReader.Create(@"\\testserver\Example.xml");
                while (!reader.EOF)
                {
                    if (reader.Name != "EventData")
                    {
                        reader.ReadToFollowing("EventData");
                    }
                    if (!reader.EOF)
                    {
                        XElement eventData = (XElement)XElement.ReadFrom(reader);
                        foreach (XElement data in eventData.Elements("Data"))
                        {
                            Console.WriteLine("{0} : {1}", (string)data.Attribute("Name"), (string)data);
                        }
                    }
                }
