    XElement el = XElement.Parse(txt);
    var mimeTypes = el.Element("MimeTypes").Elements("MimeType");
    var dictionary = mimeTypes.SelectMany(x => x.Attribute("Extensions").Value.Split(';').Select(
                                                   ext => new
                                                    {
                                                        Key = ext,
                                                        Value = x.Attribute("Type").Value
                                                     }
                                                  )
                                         ).ToDictionary( x => x.Key, y => y.Value);
