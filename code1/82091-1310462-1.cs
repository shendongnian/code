    abstract class A
    {
        public A()
        {
        }
        protected string GenerateName(string someArg)
        {
            // complicated logic to generate the name
        }
    }
    class B : A
    {
        public B(string someArg) : base()
        {
            Name = base.GenerateName(someArg);
        }
        public string Name { set; get; }
    }
