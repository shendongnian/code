    var xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <settings>
      <key name = ""setting_name"">true</key>
    </settings> ";
    
    var xmlDoc = new XmlDocument();
    xmlDoc.LoadXml(xml);
    var keys = xmlDoc.SelectNodes("//settings/key[@name=\"setting_name\"]");
    Console.WriteLine(keys[0].InnerText);
