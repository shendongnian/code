    abstract class ClassBase
    {
        public abstract string Test { get; }
    }
    class ClassDerive : ClassBase
    {
        string _s;
        protected void setTest(string s)
        {
            _s = s;
        }
        public override string Test
        {
            get { return _s; }
        }
    }
    class ClassDerive2 : ClassDerive
    {
        public new string Test
        {
            get { return base.Test; }
            set { setTest(value); }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cd2 = new ClassDerive2();
            cd2.Test = "asdf";
            Console.WriteLine(cd2.Test);
        }
    }
