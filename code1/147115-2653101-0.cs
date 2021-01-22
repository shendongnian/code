     XDocument xmlDoc = XDocument.Load(GalleryFilePath);
                var x = from c in xmlDoc.Descendants("Album")
                        where c.Attribute("GalleryId").Value.Equals(GalleryId)
                        orderby c.Attribute("Title").Value descending
                        select new
                        {
                            Title = c.Element("Photo").Attribute("Title").Value,
                            URL = c.Element("Photo").Attribute("URL").Value,
                            DateAdded = c.Element("Photo").Attribute("DateAdded").Value
                        };
