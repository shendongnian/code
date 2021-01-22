    using System;
    
    public class Test
    {
        static void Main()
        {
            for (int i=0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                   Console.WriteLine("i={0} j={1}", i, j);
                   if (j == i + 2)
                   {
                       goto end_of_loop;   
                   }
                }
                Console.WriteLine("After inner loop");
                end_of_loop: {}
            }
        }
    }
