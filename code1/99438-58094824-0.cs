    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace GuessTheDay
    {
    class Program
    {
        static void Main(string[] args)
        { 
     Console.WriteLine("Enter the Day Number ");
     int day = int.Parse(Console.ReadLine());
     Console.WriteLine(" Enter The Month");
    int month = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter Year ");
    int year = int.Parse(Console.ReadLine());
    DateTime mydate = new DateTime(year,month,day);
    string formatteddate = string.Format("{0:dddd}", mydate);
    Console.WriteLine("The day should be " + formatteddate);
    }  
     } 
       }
