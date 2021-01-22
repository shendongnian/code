    class Program
    {
        static void Main(string[] args)
        {
            var result = myMethod(100.ToMiles());
            //Miles miles = 100.ToMiles();
        }        
    }
    static class IntExtensions
    {
        public static Miles ToMiles(this int miles)
        {
            return new Miles(miles);
        }
    }
    struct Miles
    {
        public int Count { get; private set; }
        public Miles(int count)
            : this()
        {
            if (count < 0)
            {
                throw new ArgumentException("miles type cannot hold negative values.");
            }
            this.Count = count;
        }
    }
