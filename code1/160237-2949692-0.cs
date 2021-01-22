    public static class StreamExtensions
    {
        public static void SerializeTo<T>(this T o, Stream stream)
        {
            new BinaryFormatter().Serialize(stream, o);  // serialize o not typeof(T)
        }
        public static T Deserialize<T>(this Stream stream)
        {
            return (T)new BinaryFormatter().Deserialize(stream);
        }
    }
    [Serializable]  // mark type as serializable
    public struct MyStruct
    {
        public string StringData;
        public MyStruct(string stringData)
        {
            this.StringData = stringData;
        }
    }
    public static void Main()
    {
        MemoryStream stream = new MemoryStream();
        new List<MyStruct> { new MyStruct("Hello") }.SerializeTo(stream);
        stream.Position = 0;
        var mylist = stream.Deserialize<List<MyStruct>>();  // specify type argument
    }
