     XElement el = XElement.Parse(txt);
                var mimeTypes = el.Element("MimeTypes").Elements("MimeType");
                var transFormed = mimeTypes.Select(x =>
                        new
                        {
                            Type = x.Attribute("Type").Value,
                            Extensions = x.Attribute("Extensions").Value.Split(';')
                        }
                           );
                Dictionary<string, string> mimeDict = new Dictionary<string, string>();
                foreach (var mimeType in transFormed)
                {
                    foreach (string ext in mimeType.Extensions)
                    {
                        if (mimeDict.ContainsKey(ext))
                            mimeDict[ext] = mimeType.Type;
                        else
                            mimeDict.Add(ext, mimeType.Type);
                    }
                }
