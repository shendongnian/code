    using System;
    
    class Test
    {
        static void Main()
        {
            string formatString = "yyyy'##'MM'##'dd' 'HH'*'mm'*'ss";
            string sampleData = "2010##02##10 07*22*15";
            Console.WriteLine(DateTime.ParseExact(sampleData,
                                                  formatString,
                                                  null));
        }
    }
