    XmlDocument doc = new XmlDocument();
    
    doc.LoadXml("<Fields>" +
                  "<Field Name='A'>" +
                    "<DataField>A</DataField>" +
                    "<Value>'AA'</Value>" +
                    "</Field>" +
                  "<Field Name='B'>" +
                    "<DataField>B</DataField>" +
                    "<Value>'BB'</Value>" +
                  "</Field>" +
                "</Fields>");
    
    String result = string.empty;
    XmlNodeList values = doc.SelectNodes("//Value");   //using Xpath
      foreach (XmlNode node in values)
      {
         result +=  node.InnerText + "," ;       
      }
    result = result.TrimEnd(',');
