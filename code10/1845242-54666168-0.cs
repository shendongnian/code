    using System;
    using System.Collections.Generic;
     namespace Indexof_in_List
     {
     class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implementation of IndexOf Method with List");
            Console.WriteLine();
            //Create an Empty List
            List<int> name = new List<int>();
                     
            
            //If the user entered empty value or nothing in the console window, the window will exit automatically
            Console.WriteLine("Enter the Input values for the List");
            //Get the Inputs for the List from the Console Window
            for (int n=0;n<5;n++)
            {
                bool check=false;
                string input = Console.ReadLine();
                check = int.TryParse(input, out int val);
                if (check)
                {
                    name.Add(val) ;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            if (name.Count != 0)
            {
                //Implement Index of any number in the list items which you have entered to the console
                int index1 = name.IndexOf(10);
                Console.WriteLine("The Index of value 10 is = {0}", name.IndexOf(10));
                if (index1!=-1)
                {
                    Console.WriteLine("The number 10 found in the List");
                }
                else
                {
                    Console.WriteLine("The Number 10 found in the List");
                }
                int index2 = name.IndexOf(1000);
                Console.WriteLine("The Index of value 1000 is ={0}", name.IndexOf(1000));
                if (index2 != -1)
                {
                    Console.WriteLine("The number 1000  found in the List");
                }
                else
                {
                    Console.WriteLine("The  Number 1000 not found in the List");
                }
                Console.WriteLine();
            }
         
            Console.ReadKey();
        }
    }
      }
