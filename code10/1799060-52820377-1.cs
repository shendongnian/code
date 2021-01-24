    class Program
    {
        static void Main(string[] args)
        {
            Vector v = new Vector { 1, 2, 3 };
            Vector squares = Pow(v, 2);
            // Squares now contains [1, 4, 9]
        }
    }
