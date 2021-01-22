           var stopwatch2 = Stopwatch.StartNew();
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(instanceXML);
            XmlNode node = xd.SelectSingleNode("//figures/figure[@id='" + stepId + "']/properties/property[@name='" + fieldData + "']");
                node.InnerXml = "<![CDATA[ " + valData + " ]]>";  
            stopwatch2.Stop();
            var xmlDocTicks = stopwatch2.ElapsedTicks;
                      
            Stopwatch stopwatch1 = Stopwatch.StartNew(); 
            XDocument doc = XDocument.Parse(instanceXML);
            XElement prop =
            (from el in doc.Descendants("figure")
             where (string)el.Attribute("id") == stepId
                select el).FirstOrDefault();
            prop.Value = valData;
            stopwatch1.Stop();
            var linqTicks = stopwatch1.ElapsedTicks;
