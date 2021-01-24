    public class Serializer
    {
        public void XMLSerializer(Response response)
        {
            string path = "D:/Serialization.xml";
            var xs = new XmlSerializer(typeof(Response));           
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
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
