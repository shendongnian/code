    string xmlString = @"<poi>
                  <city>stockholm</city>
                  <country>sweden</country>
                  <gpoint>
                    <lat>51.1</lat>
                    <lng>67.98</lng>
                  </gpoint>
              </poi>";
            try
            {
                XElement x = XElement.Parse(xmlString);
                var latLng = x.Element("gpoint");
              
                Console.WriteLine(latLng.Element("lat").Value);
                Console.WriteLine(latLng.Element("lng").Value);
            }
            catch
            {
            }
