    using System;
    
    public class Test
    {
        static void Main()
        {
            int size = ReadInt32FromConsole("Please enter array size");
            
            int[] array = new int[size];
            for (int i=0; i < size; i++)
            {
                array[i] = ReadInt32FromConsole("Please enter element " + i);
            }
            
            Console.WriteLine("Finished:");
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }
        
        static int ReadInt32FromConsole(string message)
        {
            Console.Write(message);
            Console.Write(": ");
            string line = Console.ReadLine();
            // Include error checking in real code!
            return int.Parse(line);
        }
    }
