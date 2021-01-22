    interface IDog
    {
        void WagTail();    //notice no implementation
        ISound Speak();    //notice no implementation
    }
    class Spaniel : IDog
    {
        public void WagTail()
        {
            Console.WriteLine("Shook my long, hairy tail");
        }
        public ISound Speak()
        {
            return new BarkSound("yip");
        }
    }
    class Terrier : IDog
    {
        public void WagTail()
        {
            Console.WriteLine("Shook my short tail");
        }
        public ISound Speak()
        {
            return new BarkSound("woof");
        }
    }
