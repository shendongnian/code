    [Serializable]
    public class A
    {
        public B B = new B();
    }
    
    public class B
    {
       public string a = "b";
    }
    
    [Serializable]
    public class C
    {
        public D D = new D();
    }
    
    [Serializable]
    public class D
    {
        public string d = "D";
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
    
            var a = typeof(A);
    
            var aa = new A();
    
            Console.WriteLine("A: {0}", a.IsSerializable);  // true (WRONG!)
    
            var c = typeof(C);
    
            Console.WriteLine("C: {0}", c.IsSerializable); //true
    
            var form = new BinaryFormatter();
            // throws
            form.Serialize(new MemoryStream(), aa);
        }
    }
