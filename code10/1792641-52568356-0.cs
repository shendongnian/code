    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    namespace StackOverflowSolver
    {
        class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Get Random Names");
                // Read every line in the file.
                List<string> nameList = new List<string>();
                using (StreamReader reader = new StreamReader("test.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        nameList.Add(line);
                    }
                }
    
                nameList.Sort();
                //you can get better variables name with replacing Value with Index
                int startValue = 0;
                //int middleValue = (nameList.Count + 1) / 2;   error
                //consider you've three elements, middleValue will be 2 
                //the array index began from 0 remeber that
                int middleValue = nameList.Count / 2;
                //int endValue = (nameList.Count + 1);          error 
                int endValue = nameList.Count-1;
                Console.WriteLine("Enter a name to search for.");
                String name = Console.ReadLine();
    
                bool nameNotFound = true;
                while ((nameNotFound) && (endValue > startValue))//add end search condition
                {
                    var compareResult = String.Compare(name, nameList[middleValue]);
                    if (compareResult < 0)
                    {
                        endValue = middleValue -1; //Substract 1
                        middleValue = endValue / 2;
                    }
                    else if (compareResult > 0)
                    {
                        startValue = middleValue +1; //Add 1
                        middleValue = (endValue - startValue) / 2 + startValue;
                    }
                    else
                    {
                        Console.WriteLine("Name " + name + " was found.");
                        nameNotFound = false;
                    }
                }
                //consider to uncommit the line below
                //Console.WriteLine("Name " + name + " not found!"); //inform not found
                Console.ReadKey();
            }
        }
    }
