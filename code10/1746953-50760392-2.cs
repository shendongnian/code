    [Serializable]
    public class MyClass
    {
        public DateTime Foo { get; private set; }
        public MyClass()
        {
            Foo = DateTime.Now;
        }
    }
