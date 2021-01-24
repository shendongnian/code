    using System;
    
    class Program
    {
        unsafe static void Main(string[] args)
        {
            int*[] pointers = new int*[5];
            for (int i = 0; i < 5; i++)
            {
                pointers[i] = Call(i);
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(pointers[i][32]);
            }
        }
    
        unsafe static int* Call(int number)
        {
            int* ints = stackalloc int[64];
            ints[32] = number;
            return ints;
        }
    }
