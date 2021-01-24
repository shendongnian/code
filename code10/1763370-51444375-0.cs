    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Averages
    {
        class Program
        {
            static void Main(string[] args)
            {
                //list to hold your numbers, way more flexible than array
                List<double> enteredNubers = new List<double>();
                //message user
                Console.WriteLine("Enter number(s) or 0 to end: ");
            
                //run this indefinitely
                while (true)
                {
                    //take user input
                    string userinput = Console.ReadLine().Trim();
                    //if user enters 0, exit this loop
                    if (userinput == "0")
                        break;
                    double num;
                    //try to convert text ot number
                    if (double.TryParse(userinput, out num))
                    {
                        //if it is successfull, add number to list
                        enteredNubers.Add(num);
                    }
                    else //else message user with errorr
                        Console.WriteLine("Wrong input. Please enter number or 0 to end");
                }
                //when loop is exited (wen user entered 0), call method that calculates average
                Average(enteredNubers);
                Console.ReadKey();
            }
            static void Average(List<double> numbers)
            {
                double sum = 0;
                //go through list and add each number to sum
                foreach (double num in numbers)
                {
                    sum += num;
                }
                //or, you can sum it using linq like this:
                //sum = numbers.Sum();
            
                //show message  - all the entered numbers, separated by comma
                Console.WriteLine("You have entered: " + string.Join(", ", numbers.ToArray()));
                //write average
                Console.WriteLine("The average is: " + sum/numbers.Count);
            }
        }
    }
