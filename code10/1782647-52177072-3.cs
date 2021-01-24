     public static int? Timesaday { get; set; } 
        static void Main(string[] args)
        {
           
        Console.WriteLine(Timesaday == null);
         //you also can check using 
         Console.WriteLine(Timesaday.HasValue);
            Console.ReadKey();
        }
