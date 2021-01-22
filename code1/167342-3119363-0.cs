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
            this.Count = count;
        }
    }
