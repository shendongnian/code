    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    
    [Serializable]
    public class MyObject {
        public int n1 = 0;
        public int n2 = 0;
        public String str = null;
    }
    
    public class Example
    {
        public static void Main()
        {
            MyObject obj = new MyObject();
            obj.n1 = 1;
            obj.n2 = 24;
            obj.str = "Some String";
            BinaryFormatter formatter = new BinaryFormatter();
            
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            sw.AutoFlush = true;
            Console.SetOut(sw);
            
            formatter.Serialize(sw.BaseStream, obj);
        }
    }
