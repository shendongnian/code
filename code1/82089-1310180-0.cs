    abstract class A
    {
        protected A(string name)
        {
            Name = name;
        }
    
        public abstract string Name
        {
            get;
            protected set;
        }
    }
    
    class B: A
    {
        public B(string name) : base(name)
        {
        }
    
        private string m_name;
    
        public override string Name
        {
            get { return "B Name: " + m_name; }
            protected set
            {
               m_name = value;
            }
        }
    }
