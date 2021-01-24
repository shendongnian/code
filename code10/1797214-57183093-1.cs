    using System;
    using System.Globalization;
    static void Main()
    {
        string[] weekDays = new CultureInfo("en-us").DateTimeFormat.DayNames;
        for (int i = 1; i <= 7; i++)
            Console.WriteLine(weekDays[i % 7]);
    }
