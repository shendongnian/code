            XDocument doc = XDocument.Parse("<ul><li>1</li><li status=\"deleted\">2</li></ul>");
            var desc = doc.Descendants();
            for(int i = desc.Count() - 1; i >= 0; i--)
            {
                XElement xe = doc.Descendants().ElementAt(i);
                if (xe.HasAttributes)
                    foreach (XAttribute xa in xe.Attributes())
                        if (xa.Name == "status" && xa.Value == "deleted")
                        {
                            xe.Remove();
                            break;
                        }
            }
