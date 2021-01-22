    //overload Leg property in Dog class and make set as private
    public abstract class Animal
    {
        public string Colour { get; protected set; }
        private int legs;
        public int Legs
        {
            get { return legs; }
            protected set { legs = value; }
        }
        //public int Legs { get; protected set; }
        public abstract string Speak();
    }
    public class Dog : Animal
    {
        public int Legs
        {
            get { return base.Legs; }
            
            private set { base.Legs = value; }
        }
        public Dog()
        {
            Legs = 4;
        }
    }
