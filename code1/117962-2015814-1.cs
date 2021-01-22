     var dictionary = (from element in settingsDoc.Descendants("MimeType")
                       from extension in element.Attribute("Extensions")
                                             .Value.Split(';')
                       select new { Type = element.Attribute("Type").Value,
                                    Extension = extension })
                       .ToDictionary(x => x.Extension,
                                     x => x.Type);
                                 
