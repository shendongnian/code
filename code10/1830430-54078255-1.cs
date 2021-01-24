        //FileStream fileStream = new FileStream(yourfile, FileMode.Open, FileAccess.Read);
        byte[] byteArray = Encoding.UTF8.GetBytes(messages);
   
        MemoryStream stream = new MemoryStream(byteArray);
        int maxchar = 1000;
        using (StreamReader streamReader = new StreamReader(stream ))
        {
            Int64 x1 = stream.Length;
            char[] fileContents = new char[maxchar];
            int charsRead = streamReader.Read(fileContents, 0, maxchar);
            // Can't do much with 0 bytes
            if (charsRead == 0)
                throw new Exception("File is 0 bytes");
            while (charsRead > 0)
            {
                x1 = x1 - maxchar;
                if (x1 > 0)
                {
                    string s = new string(fileContents);
                    
                     using (var streamWriter = File.CreateText(Path.Combine(@"C:\TEMP", $"File-{ DateTime.Now.ToString("yyyyMMddHHmmssfff")}.json")))
                {
                    using (var writer = new JsonTextWriter(streamWriter))
                    {
                        writer.Formatting = Formatting.Indented;
                        writer.WriteStartObject();
                        writer.WritePropertyName("Data");
                        writer.WriteStartArray();
                        writer.WriteRawValue(JsonConvert.SerializeObject(s));
                        writer.WriteEndArray();
                        writer.WriteEndObject();
                    }
                }
                    charsRead = streamReader.Read(fileContents, 0, maxchar);
                }
                else
                {
                    int m = (int)(((x1 + maxchar) % maxchar));
                    string messagechunk = new string(fileContents, 0, m);
                  
                     using (var streamWriter = File.CreateText(Path.Combine(@"C:\TEMP", $"File-{ DateTime.Now.ToString("yyyyMMddHHmmssfff")}.json")))
                {
                    using (var writer = new JsonTextWriter(streamWriter))
                    {
                        writer.Formatting = Formatting.Indented;
                        writer.WriteStartObject();
                        writer.WritePropertyName("Data");
                        writer.WriteStartArray();
                        writer.WriteRawValue(JsonConvert.SerializeObject(messagechunk));
                        writer.WriteEndArray();
                        writer.WriteEndObject();
                    }
                }
                    charsRead = streamReader.Read(fileContents, 0, m);
                }
            }
        }
        
