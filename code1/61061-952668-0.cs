    using System;
    using System.Collections.Generic;
    using System.Linq;
   
    static class TicketPrice
    {
        private static readonly IList<KeyValuePair<Int32, String>> AgeAdmissionMap =
            new List<KeyValuePair<Int32, String>>
                {
                    new KeyValuePair<Int32, String>(0, "FREE!"),
                    new KeyValuePair<Int32, String>(5, "$5."),
                    new KeyValuePair<Int32, String>(18, "$10."),
                    new KeyValuePair<Int32, String>(56, "$8.")
                };
    
        public static void Main(String[] args)
        {
            Console.WriteLine("Please Enter Your Age!");
    
            UInt32 age;  
            while (!UInt32.TryParse(Console.ReadLine(), out age)) { }
    
            String admission = TicketPrice.AgeAdmissionMap
                .OrderByDescending(pair => pair.Key)
                .First(pair => pair.Key <= age)
                .Value;
    
            Console.WriteLine(String.Format(
                "You are {0} and the admission is {1}",
                age,
                admission));
        }
    }
