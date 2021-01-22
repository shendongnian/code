    class Program
    {
        static void Main(string[] args)
        {
            Derived d = new Derived();
            d.Property = "AWESOME";
        }
    }
    class Base
    {
        string _baseProp;
        public virtual string Property 
        { 
            get 
            {
                return "BASE_" + _baseProp;
            }
            set
            {
                _baseProp = value;
                //do work with the base property which might 
                //not be exposed to derived types
                //here
                Console.Out.WriteLine("_baseProp is BASE_" + value.ToString());
            }
        }
    }
    class Derived : Base
    {
        string _prop;
        public override string Property 
        {
            get { return _prop; }
            set 
            { 
                _prop = value; 
                base.Property = value;
            } //<- put a breakpoint here then mouse over BaseProperty, 
              //   and then mouse over the base.Property call inside it.
        }
        public string BaseProperty { get { return base.Property; } private set { } }
    }
