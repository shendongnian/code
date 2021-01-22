    static void Main(string[] args)
            {
                
                print(0);
            }
    
            public static void print(int i)
            {
                if (i >= 0 && i<=10)
                {
                  
                    i = i + 1;
                    Console.WriteLine(i + " ");
                    print(i);
                }
    }
