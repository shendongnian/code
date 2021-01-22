    using System;
    using System.Globalization;
    
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = DateTime.Parse("26/10/2009 8:47:39 AM",
                CultureInfo.GetCultureInfo("en-GB"));
        }
    }
    
