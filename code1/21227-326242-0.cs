    abstract class Mother
    {
        private readonly myInt;
        public int MyInt { get { return myInt; } }
        protected Parent(int myInt)
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
