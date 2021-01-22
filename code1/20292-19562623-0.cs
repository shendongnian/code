        public static string ToBinHex(byte[] bytes)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.ConformanceLevel = ConformanceLevel.Fragment;
            xmlWriterSettings.CheckCharacters = false;
            xmlWriterSettings.Encoding = ASCIIEncoding.ASCII;
            MemoryStream memoryStream = new MemoryStream();
            using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings))
            {
                xmlWriter.WriteBinHex(bytes, 0, bytes.Length);
            }
            return Encoding.ASCII.GetString(memoryStream.ToArray());
        }
