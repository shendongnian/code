            class DateTest
            {
                static void Main(string[] args)
                {
                    Date In1 = new Date(7, 4, 2004);
                    Date In2 = new Date(11, 1, 2003);
    
                    Console.WriteLine("The initial date is: {0}", In1.DisplayDate());
                }
            }
    
    
            class Date
            {
                private int Month { get; set; }
                private int Day { get; set; }
                private int Year { get; set; }
    
                public Date(int M, int D, int Y)
                {
                    Month = M;
                    Day = D;
                    Year = Y;
                }
    
                public string DisplayDate()
                {
                    return $"{Month}/{Day}/{Year}";
                }
            }
