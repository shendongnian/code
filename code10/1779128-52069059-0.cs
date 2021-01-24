        string XMLStored = MainFormRef.GetExportConfigForCurrentQuery();
        if (XMLStored.Length > 0)
        {
            IIDExportObject ExportConfig = new IIDExportObject();
            try
            {
                var serializer = new XmlSerializer(ExportConfig.GetType());
                // Now we need to build a Stream from the String to use in the XMLReader
                byte[] byteArray = Encoding.UTF8.GetBytes(XMLStored);
                MemoryStream stream = new MemoryStream(byteArray);
                // Now we need to use a StreamReader to get around UTF8 vs UTF16 issues
                //   A little cumbersome - but it works
                using (StreamReader sr = new StreamReader(stream, false))
                {
                    using (var reader = XmlReader.Create(sr))
                    {
                        ExportConfig = (IIDExportObject)serializer.Deserialize(reader);
                    }
                }
            }
            catch
            {
            }
