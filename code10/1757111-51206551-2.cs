            XDocument lDoc = new XDocument();
            int counter = 0;
            foreach (var fileName in multipleFileNames)
            {
                try
                {
                    counter++;
                    if (lCounter <= 1)
                    {
                        doc = XDocument.Load(fileName);
                    }
                    else
                    {
                        XDocument doc2 = XDocument.Load(fileName);
                        IEnumerable<XElement> elements = doc2.Element("Language")
                            .Elements();
                        doc.Root.Add(elements);
                    }
                }
                return Deserialize(lDoc);
