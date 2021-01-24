    using System.Runtime.Serialization.Formatters.Binary;
    BinaryFormatter formatter = new BinaryFormatter();
    using(var ms = new MemoryStream())
    {
       var array = new int[100, 100];
       array [0, 1] = 57; // simple test data to validate the output.
       formatter.Serialize(ms, array );
       ms.Position = 0; // rewind the stream to deserialize it.
       var copied = formatter.Deserialize(ms);
    }
