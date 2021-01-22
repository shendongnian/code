    public class Dog : Animal
    {
        public Dog(string name) : base(name)
        {
        }
        public override string WhatAmI
        {
            get { return "Dog"; }
        }
    }
    public class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
        }
        public override string WhatAmI
        {
            get { return "Cat"; }
        }
    }
