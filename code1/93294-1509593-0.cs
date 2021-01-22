    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyObject() { Prop1 = "Hello World!!!" };
            //===
            var bf = new BinaryFormatter();
            using (var fs = File.Open("myobject.bin", FileMode.Create, 
                                      FileAccess.Write, FileShare.None))
                bf.Serialize(fs, obj);
            //===
            MyObject restoredObj = null;
            using (var fs = File.OpenRead("myobject.bin"))
                restoredObj = bf.Deserialize(fs) as MyObject;
            //===
            var xSer = new XmlSerializer(obj.GetType());
            using (var fs = File.Open("myobject.xml", FileMode.Create, 
                                      FileAccess.Write, FileShare.None))
                xSer.Serialize(fs, obj);
            //===
            MyObject restoredObjXml = null;
            using (var fs = File.OpenRead("myobject.xml"))
                restoredObjXml = xSer.Deserialize(fs) as MyObject;
        }
    }
    [Serializable()]
    [XmlRoot("myObject")]
    public class MyObject
    {
        [XmlAttribute("prop1")]
        public string Prop1 { get; set; }
    }
