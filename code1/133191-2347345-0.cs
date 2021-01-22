    using System;
    
    namespace AddMinusDivideMultiply
    {
        class Program
        {
            public static int i, j;
    
            public static void Main()
            {
                try
                {
    
                    Console.Write("Please Enter The First Number  :");
                    string temp = Console.ReadLine();
                    i = Int32.Parse(temp);
    
                    Console.Write("Please Enter The Second Number :");
                    temp = Console.ReadLine();
                    j = Int32.Parse(temp);
    
                }
                catch (Exception e)
                {
                    Console.WriteLine(" An Execption was thrown: {0}", e.Message);
                }
    
                Terms.Minus(); 
            }
        }
      
    
        class Terms
        {
            public static void Add()
            {
                int add;
                add = Program.i + Program.j;
                Console.WriteLine("The Addition Of The First and The Second Number is {0}", add);
            }
    
            public static void Minus()
            {
            int minus;
            minus = Program.i - Program.j;
            Console.WriteLine("The Subraction Of The First and The Second Number is {0}", minus);
            }
        }
    }
