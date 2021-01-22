    public static DateTime DaysSince1900(int days)
    {
        return new DateTime(1900, 1, 1).AddDays(days);
    }
       
     DateTime time = DaysSince1900(39820);
     Console.WriteLine(time.ToShortDateString()); //will result in "1/9/2009"
