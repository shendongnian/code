    string s = "01:15:27";
    
    int hours = 0;
    int minutes = 0;
    int seconds = 0;
    TimeSpan ts;
    
    if (TimeSpan.TryParse(s, out ts))
    {
        hours = ts.Hours;
        minutes = ts.Minutes;
        seconds = ts.Seconds;
    }
    else
    {
        //Your string is not in time format
    }
    
    Console.WriteLine("Hours:" + hours);
    Console.WriteLine("Minutes:" + minutes);
    Console.WriteLine("Seconds:" + seconds);
    Console.ReadLine();
