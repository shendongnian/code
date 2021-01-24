    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Test
    {
        class Program
        {
            public int Data { get; set; }
            static void Main(string[] args)
            {
                Console.WriteLine("Enter input:");
                string line = Console.ReadLine();
    
                var operatorObject = new Operator(); //You have to add reference, If is not.
                var result = operatorObject.GetAdd(data);
    
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }
    }
