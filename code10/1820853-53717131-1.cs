    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace test
    {
        class Program
        {
            static void Main(string[] args)
            {
                String input = "K A M Paul Silvester";
                String[] nameaArr = input.Split(' ');
                String firstName = nameaArr[nameaArr.Length - 2];
                String secondName = nameaArr[nameaArr.Length - 1];
    
                String name = firstName + " " + secondName;
                Console.WriteLine(name);
                Console.ReadKey();
            }
        }
    }
