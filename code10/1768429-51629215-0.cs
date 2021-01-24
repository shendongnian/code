    using System.IO;
    using System;
    
    class Program
    {
        static void Main()
        {
            DateTime fromDate = new DateTime(2018,8,1);
            DateTime toDate = new DateTime(2018,8,15);
            Console.WriteLine("From: "+fromDate.ToString("dd/MM/yyyy"));
            Console.WriteLine("To  : "+toDate.ToString("dd/MM/yyyy"));
            
            DateTime startDate = fromDate;
            
            do
            {
                Console.WriteLine(startDate.ToString("dd/MM/yyyy")+"-"+startDate.AddDays(6).ToString("dd/MM/yyyy"));
                startDate = startDate.AddDays(7);
            }
            while(startDate < toDate.AddDays(1));
        }
    }
