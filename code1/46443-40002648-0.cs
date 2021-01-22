    You could just use the below line instead of calling a separate function:
    
    using System;
    
    public class Test
    {
        static void Main()
        {
            Console.WriteLine("Please enter array size");
            int size = Convert.ToInt32(Console.ReadLine());
    
            int[] array = new int[size];
            for (int i=0; i < size; i++)
            {
                Console.WriteLine("Please enter element " + i);
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
    
            Console.WriteLine("Finished:");
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }
