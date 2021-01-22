        public abstract class Animal
        {
            public string Colour { get; protected set; }
            public virtual int Legs { get; protected set; }
            public abstract string Speak();
        }
        public class Dog : Animal
        {
            public Dog()
            {
                Legs = 4;
            }
            public override int Legs
            {
                get
                {
                    return base.Legs;
                }
                private set
                {
                    base.Legs = value;
                }
            }
            public override string Speak()
            {
                return "Woof";
            }
        }
