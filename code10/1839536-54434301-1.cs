    string s = "00:15:27";
    
    int minute = 0;
    TimeSpan ts;
    
    if (TimeSpan.TryParse(s, out ts))
    {
        minute = ts.Minutes;
    }
    else
    {
        //Your string is not in proper time format
    }
    
    Console.WriteLine("Minute:" + minute);
    Console.ReadLine();
    
