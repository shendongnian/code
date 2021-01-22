    abstract class Mother
    {
        private readonly int myInt;
        public int MyInt { get { return myInt; } }
        protected Mother(int myInt)
        {
            this.myInt = myInt;
        }
    }
    class Daughter : Mother
    {
        public Daughter() : base(1)
        {
        }
    }
