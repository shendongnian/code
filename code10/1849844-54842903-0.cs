    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter how many characters your password will have");
            int num1 = int.Parse(Console.ReadLine());
            int letters = 0;
            int numbers = 0;
            for (int i = 0; i < num1; i++)
            {
                Console.WriteLine("Please enter the character");
                char character = char.Parse(Console.ReadLine());
                if (character >= 'A' && character <= 'Z' || character >= 'a' && character <= 'z')
                {
                    letters += 1;
                }
                if(character >= '0' && (int)character <= '9')
                {
                    numbers += 1;
                }
                if (character <= 'A' && character >= 'Z' || character <= 'a' && character >= 'z' || character <= '0' && (int)character >= '9')
                {
                    Console.WriteLine("you have entered invalid character");
                }
            }
            if(letters >= numbers)
            {
                Console.WriteLine("The password has " + num1 + " characters and its legal");
            }
            else
            {
                Console.WriteLine("The password has " + num1 + " characters and it is illegal");
            }
            Console.ReadLine();
        }
    }
}
