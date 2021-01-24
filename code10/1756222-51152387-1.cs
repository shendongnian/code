    var s = new ScriptBuilder();
    if (number != 999)
    {
        s.NewLine(1);
        s.WriteLine("SUCCESS");
    }
    else if (number > 1)
    {
        s.WriteLine("NUMBER IS BIGGER THAN 1");
    }
    else if (number > 2)
    {
        s.WriteLine("NUMBER IS BIGGER THAN 2");
    }
    else
    {
         s.NewLine(1);
         s.WriteLine("FAIL");
    }
