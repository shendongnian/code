    using System;
    using System.Collections.Generic;
    namespace ListProgram
    {
     class Program
     {
        static void Main(string[] args)
        {
            string varListInput = null;
            Boolean varIsValid = true;
            Int32 intTime = 3000000;
            while (varIsValid) //don't really understand why you need/have this while loop, but not the question
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to OTC CIS120"); //you're already using WriteLine, you don't need to append \n
                    Console.WriteLine("ACME Co. Item Locator List Program");
                    Console.WriteLine(); //for one line spacing between header and user input
                    var ItemList = new List<string>();
                    for (int i = 0; i < 10; i++) // Continue For Loop until i is > List amount.
                    {
                        Console.WriteLine($"{i + 1}: Enter Item Name To Add To Inventory");
                        varListInput = Console.ReadLine(); // User inputs value into field.
                        ItemList.Add(varListInput);
                    }
                    Console.WriteLine("Items Added To Inventory Are: ");
                    //just personal perfence to do it this way rather than list.reverse()
                    //item count is 10, but the highest index is only 9.
                    for (int i = (ItemList.Count - 1); i >=0; i--)
                    {
                        var item = ItemList[i];//need to get the current item from the list
                        Console.WriteLine($"{i +  1}: {item}");
                    }
                    System.Threading.Thread.Sleep(intTime);//please do NOT EVER use Thread.Sleep in production code
                }
                catch (Exception e)//since Console.ReadLine returns a string I'm not sure what errors this code would produce, therefore when it would stop.
                {
                    Console.WriteLine("The Program Has an Error: " + e.Message);
                    varIsValid = false;
                    System.Threading.Thread.Sleep(intTime);
                    Environment.Exit(0); //Exit the program
                }
            }
        }
      }
    }
