    [Serializable]
    public class A
    {
        public A()
        {
            this.instanceOne = new B();
            this.instanceTwo = new B();
        }
        public B instanceOne { get; set; }
        public B instanceTwo { get; set; }
    }
    [Serializable]
    public class B
    {
        public B()
        {
            this._c = new C();
            this._c.value = 10;
        }
        private C _c;
    }
    [Serializable, XmlRoot(ElementName = "MyC", Namespace = "MyNS")]
    public class C
    {
        public int value { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new XmlSerializer(typeof(A));
            var a = new A();
            try
            {
                var fs = new System.IO.FileStream("test.xml", System.IO.FileMode.Create);
                serializer.Serialize(fs, a);
                fs.Close();
                A d = (A)serializer.Deserialize(new System.IO.FileStream("test.xml", System.IO.FileMode.Open));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
