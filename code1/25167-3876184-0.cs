    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    
        namespace ConsoleApplication6
        {
            internal class Program
            {
                private static void Main(string[] args)
                {
                    List<ImyInterface> list = new List<ImyInterface>();
        
                    list.Add(new MyClass {MyData = "Test1", SpecialData = "special"});
                    list.Add(new MyOtherClass {MyData = "Test2", OtherData = "other"});
        
                    Serialize("c:\\test.dat", list);
                    List<ImyInterface> theList = Deserialize<List<ImyInterface>>("c:\\test.dat");
                }
        
                public static void Serialize<T>(string filename, T objectToSerialize)
                {
                    Stream stream = File.Open(filename, FileMode.Create);
                    BinaryFormatter bFormatter = new BinaryFormatter();
                    bFormatter.Serialize(stream, objectToSerialize);
                    stream.Close();
                }
        
                public static T Deserialize<T>(string filename)
                {
                    Stream stream = File.Open(filename, FileMode.Open);
                    BinaryFormatter bFormatter = new BinaryFormatter();
                    T objectToSerialize = (T) bFormatter.Deserialize(stream);
                    stream.Close();
                    return objectToSerialize;
                }
            }
        
            public interface ImyInterface
            {
                string MyData { get; set; }
            }
        
            [Serializable]
            public class MyClass : ImyInterface
            {
                public string MyData { get; set; }
                public string SpecialData { get; set; }
            }
        
            [Serializable]
            public class MyOtherClass : ImyInterface
            {
                public string MyData { get; set; }
                public string OtherData { get; set; }
            }
        }
