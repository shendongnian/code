    class BaseClass
    {
        int a;
        int b;
        protected BaseClass()
        { }
        protected BaseClass(int i)
        {
            a = i;
        }
        protected void Update(int i)
        {
            a = i;
            Console.Write("Hello World ");
        }
    }
    class TestChild : BaseClass
    {
        public TestChild(int i) : base(i) //send your constuctor to your base class
        { }
        public TestChild()
        { }
        public void Update(int i)
        {
            base.Update(i);
            Console.Write(i.ToString());
        }
    }
    private void btnTest_Click(object sender, EventArgs e)
    {
        TestChild t = new TestChild(); // create instance as your child
        t.Update(100);
    }
