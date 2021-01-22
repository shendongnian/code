    using System;
    using System.Collections;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                //ArrayList
                /*
                 An ArrayList doesn't use a LinkedList as the internal data structure! .we can store any type of objects      
                 */
                ArrayList list = new ArrayList();
                list.Add("1"); // not strongly type,you can enter any object types (int,string decimals, etc..)
                list.Add(1);
                list.Add(1.25);
    
                //Array
                /*
                 must declare length.
                 */
                string[] array = new string[3]; // you must declare object types
                array[0] = "1";
                //array[1] = 1; this get error becoz array is storngly typed. // this print empty value when you run it
                array[2] = "stongly typed";
                Console.WriteLine("------- ARRAYLIST ITEMS ---------");
                foreach (var i in list) {
                    Console.WriteLine(i);
                }
    
                Console.WriteLine("--------- ARRAY ITEMS -----------");
                foreach (var i in array)
                {
                    Console.WriteLine(i);
                }
    
                Console.ReadKey(); 
            }
        }
    }
