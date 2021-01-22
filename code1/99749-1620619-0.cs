    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    
    [Serializable]
    class A
    {
    public static void Serialize(object obj,string filepath)
    {
    Formatter f = new BinaryFormatter();
    f.Serialize(new FileStream(filepath,FileMode.Create),obj);
    }
    public static A Deserialize(string filepath)
    {
    Formatter f = new BinaryFormatter();
    return  f.Deserialize(new FileStream(filepath, FileMode.Open)) as A;
    }
    }
