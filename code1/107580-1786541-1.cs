    using System.Collections.Generic;
    
    namespace strings1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> names = new List<string> { 
                    "SCO_InsBooking_1.pdf", 
                    "SCO_InsBooking_10.pdf", 
                    "SCO_InsBooking_100.pdf", 
                    "SCO_InsBooking_1000.pdf" };
    
                List<string> numbers = new List<string>();
                foreach (string item in names)
                {
                    numbers.Add(item.Replace("SCO_InsBooking_", string.Empty).Replace(".pdf",string.Empty));
                }
            }
        }
    }
