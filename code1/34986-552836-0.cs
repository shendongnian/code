    using System.Xml;
    using System.IO;
    ...
    string xml = @"<poi>
                      <city>stockholm</city>
                      <country>sweden</country>
                      <gpoint>
                        <lat>51.1</lat>
                        <lng>67.98</lng>
                      </gpoint>
                  </poi>";
    XmlDocument d = new XmlDocument();
    d.Load(new StringReader(xml));
    Console.WriteLine(d.SelectSingleNode("/poi/gpoint/lat").InnerText);
    Console.WriteLine(d.SelectSingleNode("/poi/gpoint/lng").InnerText);
