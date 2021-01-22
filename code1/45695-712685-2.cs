        interface Animal
    {
        void EatRoots();
        void EatLeaves();
    }
    interface Animal2
    {
        void Sleep();
    }
    class Wombat : Animal, Animal2
    {
        // Implicit implementation of Animal2
        public void Sleep()
        {
        }
        // Explicit implementation of Animal
        void Animal.EatRoots()
        {
        }
        void Animal.EatLeaves()
        {
        }
    }
