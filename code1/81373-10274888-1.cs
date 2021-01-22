    namespace Program
    {
        class Program
        {
            static void Main(string[] args)
            {
                // print triangle
                int n = 5;
                /* three phrase: 
                 * first: find first location of the line
                 * second: print increasing
                 * third: print decreasing */
                int k=n;
                for (int i = 0; i <n; i++)  //print n line
                {
                    //  first
                    for (int j = 1; j <= k; j++) Console.Write(" ");
                    // second
                    for (int j = 1; j <= i; j++) Console.Write(j);
                    // third
                    for (int j = i + 1; j >= 1; j--) Console.Write(j);
                    k--;
                    Console.WriteLine();
                }
      
            }
        }
    }
