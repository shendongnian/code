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
