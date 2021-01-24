    using System;
    
    namespace ClassLibrary3
    {
        public static class StaticDate
        {
            static StaticDate()
            {
                //Initialize Date
                var date = DateTime.Now;
                Year = date.Year;
                Month = date.Month;
                Day = date.Day;
            }
    
            public static readonly int Year;
            public static readonly int Month;
            public static readonly int Day;
        }
    
        public class SomeOtherClass
        {
            public void MethodThatNeedsDate()
            {
                var year = StaticDate.Year;
                var day = StaticDate.Day;
            }
        }
    }
