    public class SerializeAny<TF> where TF : new()
    {
        public static TF Deserialize(string serializedData)
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(TF));
                TF collection;
                using (var xmlReader = new XmlTextReader(serializedData, XmlNodeType.Document, null))
                {
                    collection = (TF)xmlSerializer.Deserialize(xmlReader);
                }
                return collection;
            }
            catch (Exception)
            {
            }
            return new TF();
        }
        public static TF DeserializeZip(string path)
        {
            try
            {
                var bytes = File.ReadAllBytes(path);
                string serializedData = Unzip(bytes);
                TF collection = Deserialize(serializedData);
                return collection;
            }
            catch (Exception)
            {
            }
            return new TF();
        }
        public static string Serialize(TF options)
        {
            var xml = "";
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(TF));
                using (var stringWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(stringWriter, options);
                    xml = stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return xml;
        }
        public static string SerializeZip(TF options, string path)
        {
            var xml = "";
            try
            {
                xml = Serialize(options);
                var zip = Zip(xml);
                File.WriteAllBytes(path, zip);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return xml;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        internal static String SerializeObject<T>(T obj, Encoding enc)
        {
            using (var ms = new MemoryStream())
            {
                var xmlWriterSettings = new System.Xml.XmlWriterSettings()
                {
                    // If set to true XmlWriter would close MemoryStream automatically and using would then do double dispose
                    // Code analysis does not understand that. That's why there is a suppress message.
                    CloseOutput = false,
                    Encoding = enc,
                    OmitXmlDeclaration = false,
                    Indent = true
                };
                using (var xw = XmlWriter.Create(ms, xmlWriterSettings))
                {
                    var s = new XmlSerializer(typeof(T));
                    s.Serialize(xw, obj);
                }
                return enc.GetString(ms.ToArray());
            }
        }
        private static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];
            int cnt;
            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }
        private static byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }
                return mso.ToArray();
            }
        }
        private static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    CopyTo(gs, mso);
                }
                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
    }
