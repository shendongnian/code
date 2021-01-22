    //Parse both strings to TimeSpan
    var ts = TimeSpan.FromHours(Double.Parse("02.500"));   
    var ts2 = TimeSpan.Parse("02:30");
    //Convert a TimeSpan to string format
    var firstFormat = ts.Hours.ToString.PadLeft(2, '0') 
                      + ":" + ts.Minutes.ToString.PadLeft(2, '0');
    //Result: 02:30
    var secondFormat = ts.TotalHours.ToString("00.000");
    //Result: 02.500
