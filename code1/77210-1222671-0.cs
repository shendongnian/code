    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    
    namespace Test
    {
        [Serializable]
        public class MyClass : ISerializable
        {
            internal Dictionary<long, string> dict = new Dictionary<long, string>();
    
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("static.dic", dict, typeof(Dictionary<long, string>));
            }
    
            public MyClass(SerializationInfo info, StreamingContext context)
            {
                dict = (Dictionary<long, string>)info.GetValue("static.dic",
                   typeof(Dictionary<long, string>));
            }
    
            public void Add()
            {
                dict.Add(31, "11");
            }
    
            public MyClass()
            {
                dict.Add(21, "11");
            }
        }
    
        public class MyClassTest
        {
            public static void Main()
            {
                MyClass myClass = new MyClass();
                myClass.Add();
    
                using (FileStream fileStream = new FileStream("test.binary", FileMode.Create))
                {
                    IFormatter bf = new BinaryFormatter();
                    bf.Serialize(fileStream, myClass);
                }
    
                using (FileStream fileStream = new FileStream("test.binary", FileMode.Open))
                {
                    IFormatter bf = new BinaryFormatter();
                    myClass = (MyClass)bf.Deserialize(fileStream);
                }
            }
        }
    }
