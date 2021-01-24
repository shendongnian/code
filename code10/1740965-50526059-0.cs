    using System.Runtime.Serialization.Formatters.Binary;
    BinaryFormatter formatter = new BinaryFormatter();
    using(var ms = new MemoryStream())
    {
       var jaggedArray = new int[100, 100];
       jaggedArray[0, 1] = 57; // simple test data to validate the output.
       formatter.Serialize(ms, jaggedArray);
       ms.Position = 0; // rewind the stream to deserialize it.
       var copied = formatter.Deserialize(ms);
    }
