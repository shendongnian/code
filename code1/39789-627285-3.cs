    public class Dog : Animal
    {
        public Dog(string name)
            : base(name)
        {
        }
        public override string WhatAmI
        {
            get { /*return dog-specific value */ }
        }
    }
