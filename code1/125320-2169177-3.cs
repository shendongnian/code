    static void Main(string[] args)
    {
        MyClass c = new MyClass();
        c.Name = "MyTest";
        Console.ReadLine();
    }
    class MyClass
    {
        private string name;
        void TestMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame currentFrame = st.GetFrame(1);
            MethodBase method = currentFrame.GetMethod();
            Console.WriteLine(method.Name);
        }
        public string Name
        {
            get { return name; }
            set
            {
                TestMethod();
                name = value;
            }
        }
    }
