    using System;
    using Microsoft.VisualBasic;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                double dAPR = 2;
                Int32 iNumberOfPayments = 12;
                double dLoanAmount = 10000;
                Console.WriteLine(Financial.Pmt((dAPR / 100) / 12, iNumberOfPayments, dLoanAmount, 0, DueDate.EndOfPeriod) * -1);
                Console.ReadLine();
            }
        }
    }
