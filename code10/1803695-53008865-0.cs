    string filePath = @".\ListXML.xml";
    using (var sw = new StringWriter())
    {
         xs.Serialize(sw, cfgIn);
         using (var fs = new StreamWriter(filePath))
         {
              fs.Write(sw.ToString());
         }
    }
