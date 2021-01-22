    class TestClass
    {
        private string _field;
    
        public string MyProperty
        {
            get { return _field; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TestClass test = new TestClass();
            PropertyInfo[] info = test.GetType().GetProperties();
            foreach(PropertyInfo i in info)
                Console.WriteLine(i.Name);
            Console.Read();
        }
    }
