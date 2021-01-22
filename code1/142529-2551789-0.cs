        if (File.Exists("my.xml")) File.Delete("my.xml");
        using (XmlWriter xmlFile = XmlWriter.Create("my.xml")) {
            Random rand = new Random();
            xmlFile.WriteStartElement("xml");
            for (int i = 0; i < 1000; i++) {
                xmlFile.WriteElementString("add", rand.Next().ToString());
            }
            xmlFile.WriteEndElement();
            xmlFile.Close();
        }
        // now we have some xml!
        using (MemoryStream ms = new MemoryStream()) {
            int origBytes = 0;
            using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
            using (FileStream file = File.OpenRead("my.xml")) {
                byte[] buffer = new byte[2048];
                int bytes;
                while ((bytes = file.Read(buffer, 0, buffer.Length)) > 0) {
                    zip.Write(buffer, 0, bytes);
                    origBytes += bytes;
                }
            }
            byte[] blob = ms.ToArray();
            string asBase64 = Convert.ToBase64String(blob);
            Console.WriteLine("Original: " + origBytes);
            Console.WriteLine("Raw: " + blob.Length);
            Console.WriteLine("Base64: " + asBase64.Length);
        }
