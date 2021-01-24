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
                Number n = new Number();
                n.setMax(20, 12);
                n.getMax();
            }
        }
    }
