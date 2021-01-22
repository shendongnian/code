    class Program
    {
        static void Main(string[] args)
        {
            using (var fs = File.OpenRead("XmlFile1.xml"))
            using (var fs2 = File.OpenRead("XmlFile2.xml"))
            {
                var xSer = new XmlSerializer(typeof(data));
                var obj = xSer.Deserialize(fs);
            //
                var xattribs = new XmlAttributes();
                var xroot = new XmlRootAttribute("dataNew");
                xattribs.XmlRoot = xroot;
                var xoverrides = new XmlAttributeOverrides();
                xoverrides.Add(typeof(data), xattribs);
                var xSer2 = new XmlSerializer(typeof(data), xoverrides);
                var obj2 = xSer2.Deserialize(fs2);
            }
        }
    }
    public class data
    {
        public string elmt1 { get; set; }
        public string elmnt2 { get; set; }
        public string elmnt3 { get; set; }
    }
