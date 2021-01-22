    DateTime birth = new DateTime(1974, 8, 29);
    DateTime today = DateTime.Now;
    TimeSpan span = today - birth;
    DateTime age = DateTime.MinValue + span;
    // Make adjustment due to MinValue equalling 1/1/1
    int years = age.Year - 1;
    int months = age.Month - 1;
    int days = age.Day - 1;
    
    // Print out not only how many years old they are but give months and days as well
    Console.Write("{0} years, {1} months, {2} days", years, months, days);
