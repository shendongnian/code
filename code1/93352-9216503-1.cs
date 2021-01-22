    static void Main(string[] args)
        {  int i,j;
            Console.WriteLine("prime no between 1 to 100");
        for (i = 2; i <= 100; i++)
        {
            int count = 0;
            for (j = 1; j <= i; j++)
            {
       
                if (i % j == 0)
                { count=count+1; }
            }
            if ( count <= 2)
            { Console.WriteLine(i); }
        }
        Console.ReadKey();
        }
