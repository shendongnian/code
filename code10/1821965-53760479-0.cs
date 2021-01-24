    var doc = new XmlDocument();
                doc.Load(@"docs/example.xml");
                var root = doc.DocumentElement;
                var PipeSelectionOptions = root.SelectNodes("PipeSelectionOptions");
                if (PipeSelectionOptions != null && root.Attributes["CoTo"].Value == "ODRDaneOgolneCOOP")
                {
                    foreach (XmlNode pipeSelectionOption in root)
                    {
                        foreach (XmlNode NastepcyRur in pipeSelectionOption)
                        {
                            if (NastepcyRur.Name == "ODRDaneOgolneNastepcyRurItem")
                            {
                                foreach (XmlNode element in NastepcyRur)
                                {
                                    if (element.Name != "IsAutoMetkaNastepnika")
                                        Console.WriteLine(element.Name + ":" + element.InnerText);
                                }
                            }
                        }
                    }
                }
    
    its working. try to convert by yourself.
