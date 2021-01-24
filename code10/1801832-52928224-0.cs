    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StackQuesionsPractice
    {
        class Program
        {
            static void Main(string[] args)
            {
         
                //These will be the current dates in your database which you said you use to calculate the months * salary
                DateTime CurrentStart = new DateTime(2013, 1, 1);
                DateTime CurrentEnd = new DateTime(2014, 2, 1);
    
                //Work out the how the difference in months between the start and end date
                var diffMonths = (CurrentEnd.Month + CurrentEnd.Year * 12) - (CurrentStart.Month + CurrentStart.Year * 12);
    
                //Monthly salary * by the difference in months to work out the expected wage due
                int MonthlySalary = 40 * diffMonths;
    
                //User inserts the new dates into the database
                DateTime NewStart = new DateTime(2013, 5, 1);
                DateTime NewEnd = new DateTime(2015, 2, 1);
    
                //Workout out the total days between the old start and end date
                var diffDays = (CurrentEnd - CurrentStart).TotalDays;
    
                //Add the total days onto the old date and check to see it it's greater than the current date
                if (CurrentStart.AddDays(diffDays) > NewStart)
                {
                    Console.WriteLine("The newly entered start date falls within the last date range saved in the database");
                }
                else {
    
                    //Salary due to the employee 
                    Console.WriteLine($"The amount of salary due is: {MonthlySalary}");
    
                }
            }
        }
    }
