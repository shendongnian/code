    var query = from device in document.Descendants("device")
                select new
                {
                    ID = device.Attribute("id").Value,
                    Name = device.Attribute("name").Value,
                    Interfaces = from deviceInterface in device.Descendants("interface")
                                 select new
                                 {
                                     ID = deviceInterface.Attribute("id").Value,
                                     Description = deviceInterface.Attribute("description")
                                 }
                };
