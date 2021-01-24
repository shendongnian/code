     using (var xmlReader = cmd.ExecuteXmlReader())
            {
               while(xmlReader.Read())
               {
                string s = xmlReader.ReadOuterXml();      
               }
     }
