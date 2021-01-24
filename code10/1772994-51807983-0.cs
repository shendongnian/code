    using System;
    
    namespace Bank
    {
    
        class FindMax
        {
            protected int max;
    
            public void setMax(int numOne, int numTwo)
            {
                if (numOne >= numTwo)
                    max = numOne;
                else
                    max = numTwo;
            }
    
    
        }
    
        class Number : FindMax
        {
            public void getMax()
            {
                Console.WriteLine(max);
            }
        }
    
        class MainClass
        {
            public static void Main(string[] args)
            {
                FindMax mx = new FindMax();
                Number n = new Number();
                mx.setMax(20, 12);
                n.getMax();
            }
        }
    }
