    class A
    {
        public virtual string P
        {
            get { return "A"; }
        }
        public A()
        {
            Console.WriteLine(this.P);
        }
    }
    class B : A
    {
        public override string P
        {
            get { return "B"; }
        }
        public B() : base() { }
    }
