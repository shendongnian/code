    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    class Program {
      static void Main(string[] args) {
        var ser = new XmlSerializer(typeof(Observation));
        var sw = new StringWriter();
        var obj = new Observation();
        ser.Serialize(sw, obj);
        Console.WriteLine(sw.ToString());
        var sr = new StringReader(sw.ToString());
        var obj2 = (Observation)ser.Deserialize(sr);
        // Compare obj to obj2 here
        //...
        Console.ReadLine();
      }
    }
    public class Observation {
      // etc...
    }
