    interface INamedObject
    {
        string Name { get; set; }
    }
    abstract class MyBaseClass
    {
        void PrintType()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }
    class MyConcreteClass : MyBaseClass, INamedObject
    {
        public MyConcreteClass()
            : base()
        {
        }
        public string Name
        {
            get;
            set;
        }
    }
