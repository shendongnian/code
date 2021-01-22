    [Serializable ]
    public class Numbers
    {
        public int no;
        public static int no1;
    }
    class Test
    {
        static void Deser()
        {
            Numbers a;
            FileStream fs = new FileStream("a1.txt", FileMode.Open );
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bs = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            a = (Numbers)bs.Deserialize(fs);
            Numbers.no1 = (int)bs.Deserialize(fs);
            fs.Close();
            Console.WriteLine(a.no + " " + Numbers.no1);
        }
        static void Ser()
        {
            Numbers a = new Numbers();
            a.no = 100;
            Numbers.no1 = 200;
    
            FileStream fs = new FileStream("a1.txt", FileMode.Create);
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bs = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bs.Serialize(fs, a);
            bs.Serialize(fs, Numbers.no1);
            fs.Close();
       }
    }
