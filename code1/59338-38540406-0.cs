    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConvertToAnyBase
    {
       class Program
        {
            static void Main(string[] args)
            {
                var baseNumber = int.Parse(Console.ReadLine());
                var number = int.Parse(Console.ReadLine());
                string conversion = "";
            
                while(number!=0)
                {
                
                    conversion += Convert.ToString(number % baseNumber);
                    number = number / baseNumber;
                }
                var conversion2 = conversion.ToArray().Reverse();
                Console.WriteLine(string.Join("", conversion2));
           }
        }
    }
