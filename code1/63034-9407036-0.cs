    public class Animal
    {
        public Animal(string name = "")
        {
            Name = name;
            Perform = Performs.Nothing;
        }
        public enum Performs
        {
            Nothing,
            Sleep,
            Eat,
            Dring,
            Moan,
            Flee,
            Search,
            WhatEver
        }
        public string Name { get; set; }
        public Performs Perform { get; set; }
    }
    public class Cat : Animal
    {
        public Cat(Types type, string name) 
            : base (name)
        {
            Type = type;
        }
        public enum Types
        {
            Siamese,
            Bengal,
            Bombay,
            WhatEver
        }
        public Types Type { get; private set; }
    }
    public class Dog : Animal
    {
        public Dog(Types type, string name)
            : base(name)
        {
            Type = type;
        }
        public enum Types
        {
            Greyhound,
            Alsation,
            WhatEver
        }
        public Types Type { get; private set; }
    }
