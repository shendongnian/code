        enum days
        {
            sunday,monday,tuesday,wednesday,thursday,friday,saturday
        }
        static void Main(string[] args)
        {
            Random r = new Random();
            Console.WriteLine(Enum.GetNames(typeof(days))[r.Next(1, 7)]);    
            Console.ReadKey();
        }
    
