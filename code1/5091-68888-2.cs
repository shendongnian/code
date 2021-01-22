    public class TestClass
    {
        public void Go(Base b)
        {
            Console.WriteLine("Base arg");
        }
        public void Go(Derived d)
        {
            Console.WriteLine("Derived arg");
        }
        public void Test()
        {
            Base obj = new Derived();
            Go(obj);
        }
    }
