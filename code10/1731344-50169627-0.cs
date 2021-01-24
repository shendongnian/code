    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Dalmata", "Fuffy", 7);
        }
    }
    class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    class Dog : Animal
    {
        public string Race { get; set; }
        public Dog(string race, string name, int age) : base(name, age)
        {
            Race = race;
        }
    }
