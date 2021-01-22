    private void generateXML(string filename)
            {
                using (XmlWriter writer = XmlWriter.Create(filename))
                {
                    writer.WriteStartDocument();
                    //new line
                    writer.WriteRaw("\n");
                    writer.WriteStartElement("treeitems");
                    //new line
                    writer.WriteRaw("\n");
                    foreach (RootItem root in roots)
                    {
                        //indent
                        writer.WriteRaw("\t");
                        writer.WriteStartElement("treeitem");
                        writer.WriteAttributeString("name", root.name);
                        writer.WriteAttributeString("uri", root.uri);
                        writer.WriteAttributeString("fontsize", root.fontsize);
                        writer.WriteAttributeString("icon", root.icon);
                        if (root.children.Count != 0)
                        {
                            foreach (ChildItem child in children)
                            {
                                //indent
                                writer.WriteRaw("\t");
                                writer.WriteStartElement("treeitem");
                                writer.WriteAttributeString("name", child.name);
                                writer.WriteAttributeString("uri", child.uri);
                                writer.WriteAttributeString("fontsize", child.fontsize);
                                writer.WriteAttributeString("icon", child.icon);
                                writer.WriteEndElement();
                                //new line
                                writer.WriteRaw("\n");
                            }
                        }
                        writer.WriteEndElement();
                        //new line
                        writer.WriteRaw("\n");
                    }
    
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    
                }
               
            }
