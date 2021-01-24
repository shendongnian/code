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
            
                //run this block of code indefinitely
                while (true)
                {
                    //take user input
                    string userinput = Console.ReadLine().Trim();
                    //if user enters 0, exit this loop
                    if (userinput == "0")
                        break;
                    double num;
                    //try to convert text to number
                    if (double.TryParse(userinput, out num))
                    {
                        //if it is successful, add number to list
                        enteredNubers.Add(num);
                    }
                    else //else message user with error
                        Console.WriteLine("Wrong input. Please enter number or 0 to end");
                }
                //when loop is exited (when user entered 0), call method that calculates average
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
                //or you can even calculate average by calling Average method on list, like numbers. Average();
            
                //show message  - all the entered numbers, separated by comma
                Console.WriteLine("You have entered: " + string.Join(", ", numbers.ToArray()));
                //write average
                Console.WriteLine("The average is: " + sum/numbers.Count);
            }
        }
    }
