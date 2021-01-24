    class Print
    {
        private static Random _random = new Random();
        public void print()
        {
             int n = _random.Next(1,5000);
             Console.WriteLine(n);
        }
    }
