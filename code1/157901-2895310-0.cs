    interface IAuxClass1
    {
        string Field1 { get; set; }
        void Method1();
        void Method2();
    }
    class AuxClass1 : IAuxClass1
    {
        string _field1;
        public string Field1
        {
            get
            {
                return _field1;
            }
            set
            {
                _field1 = value;
            }
        }
        // another fields. maybe many fields maybe several properties 
        public void Method1()
        {
            // some action 
        }
        public void Method2()
        {
            // some action 2 
        }
    }
    public class MyClass : ServiceContainer
    {
        public MyClass()
        {
            this.AddService(typeof(IAuxClass1), new AuxClass1());
        }
        public MyClass(IAuxClass1 auxClassInstance)
        {
            this.AddService(typeof(IAuxClass1), auxClassInstance);
        }
        public IAuxClass1 AuxClass
        {
            get
            {
                return (this.GetService(typeof(IAuxClass1)) as IAuxClass1);
            }
        }
    }
