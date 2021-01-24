    public class Serializer
    {
        public void XMLSerializer(Response response)
        {
            string path = "D:/Serialization.xml";
            var xs = new XmlSerializer(typeof(Response));
            FileMode fm;
            if (!File.Exists(path))
            {
                fm = FileMode.OpenOrCreate;
            }
            else
            {
                fm = FileMode.Append;
            }
            using (var fs = new FileStream(path, fm))
            {
                using (var sw = new StreamWriter(fs))
                {
                    using (var xw = new XmlTextWriter(sw))
                    {
                        xw.Formatting = System.Xml.Formatting.Indented;
                        xs.Serialize(xw, response);
                        xw.Flush();
                    }
                }
                fs.Close();
            }
        }
    }
