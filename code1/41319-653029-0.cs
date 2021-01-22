    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                const double FEDERAL_TAX_RATE= 0.28;
                const double SOCIAL_SECURITY_RATE = 0.0765;  // I am assuming the 7.65 was supposed to be 7.65%... therefore it should be 0.0765
    
                Console.WriteLine("       WEEKLY PAYROLL INFORMATION");
                Console.WriteLine("       --------------------------");
                Console.Write("\n       Please enter the employer's name: ");
                string empName = Console.ReadLine();
                Console.Write("\n       Please enter the number of hours worked this week: ");
                double hrsWorked = Convert.ToDouble(Console.ReadLine());
                Console.Write("\n       Please enter the number of OVERTIME HOURS worked this week: ");
                double ovtWorked = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n       Please enter employee's HOURLY PAY RATE: ");
                double payRate = Convert.ToDouble(Console.ReadLine());
                double grossPay = CalculateGrossPay(hrsWorked, payRate, ovtWorked);
                double federalTaxWithheld = CalculateTax(grossPay, FEDERAL_TAX_RATE);
                double socialSecurityWithheld = CalculateTax(grossPay, SOCIAL_SECURITY_RATE);
    			double netPay = CalculateNetPay(grossPay, federalTaxWithheld + socialSecurityWithheld);
    			
                Console.WriteLine("\n\n       The weekly payroll information summary for: " + empName);
                Console.WriteLine("\n       Gross pay:                             {0:C2}    ", grossPay);
                Console.WriteLine("       Federal income taxes witheld:          {0:C2}      ", federalTaxWithheld);
                Console.WriteLine("       Social Security taxes witheld:         {0:C2}    ", socialSecurityWithheld);
                Console.WriteLine("       Net Pay:                               {0:C2}", netPay);
    			
    			Console.ReadLine();  // You don't need this line if your running from the command line to begin with
            }
    		
    		static double CalculateGrossPay(double HoursWorked, double PayRate, double OvertimeHoursWorked)
    		{
    			return PayRate * (HoursWorked + 1.5 * OvertimeHoursWorked);
    		}
    		
    		static double CalculateTax(double GrossPay, double TaxRate) 
    		{
    			return GrossPay * TaxRate;
    		}
    		
    		static double CalculateNetPay(double GrossPay, double TaxAmount)
    		{
    			return GrossPay - TaxAmount;
    		}
        }
    }
