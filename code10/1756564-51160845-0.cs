    abstract class Animal
    {
        public abstract int Rarity { get; }
        public int Amount { get; set; }
    }
    class Cat : Animal
    {
        public override int Rarity => 32;
    }
    class Dog : Animal
    {
        public override int Rarity => 15;
    }
    class Tiger : Animal
    {
        public override int Rarity => 3;
    }
