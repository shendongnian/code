    class Program
    {
        private static List<int> _items = new List<int>();
        private static List<int> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value ?? new List<int>();
            }
        }
        static void Main(string[] args)
        {
            //APPROACH 5
            Items = GetIntegerStuff();
        }
        private static Random Random = new Random();
        private static List<int> GetIntegerStuff()
        {
            switch (Random.Next(0, 2))
            {
                case 0:
                    return null;
                    break;
                default:
                    return new List<int>();
                    break;
            }
        }
    }
