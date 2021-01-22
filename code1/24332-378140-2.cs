    using System;
    
    class Test
    {
        static void Main() {}
        
        static void DeclareInside()
        {
            for (int i=0; i < 10; i++)
            {
                bool x = false;
                for (int j=5; j < 20; j++)
                {
                    if (i == j)
                    {
                        x = true;
                        break;
                    }
                    if (x)
                    {
                        Console.WriteLine("Yes");
                    }
                }
            }
        }
        
        static void DeclareOutside()
        {
            bool x;
            for (int i=0; i < 10; i++)
            {
                x = false;
                for (int j=5; j < 20; j++)
                {
                    if (i == j)
                    {
                        x = true;
                        break;
                    }
                    if (x)
                    {
                        Console.WriteLine("Yes");
                    }
                }
            }
        }
    }
