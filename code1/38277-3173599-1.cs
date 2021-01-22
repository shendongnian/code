    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
...
    long size = 0;
    object o = new object();
    using (Stream s = new MemoryStream()) {
    	BinaryFormatter formatter = new BinaryFormatter();
    	formatter.Serialize(s, o);
    	size = s.Length;
    }
