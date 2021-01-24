    using System;
    namespace App
    {
        class AppClass
        {
            public int input1;
            public int input2;
            public string operation;
            public int output;
            static void Main()
            {
    
            }
            void user_input()
            {
                while (operation != "+" || operation != "-")
                {
                    Console.WriteLine("Would you like to Add or Subtract?");
                    operation = Convert.ToString(Console.ReadLine());
                }
    
                Console.WriteLine("Please enter the first input:");
                input1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the second input:");
                input2 = Convert.ToInt32(Console.ReadLine());
            }
            void do_math()
            {
    
                if (operation == "+")
                {
                    output = input1 + input2;
                }
                else
                {
                    output = input1 - input2;
                }
            }
            void display()
            {
                Console.WriteLine("The answer is {0}", output);
            }
    
        }
    
    }
