    string inputStringg = "‪120000";
    inputStringg        = new string(inputStringg.Where(c => char.IsLetterOrDigit(c)).ToArray());
    int numvalue;
    numvalue            = int.Parse( inputStringg );
    System.Diagnostics.Trace.WriteLine( "" + numvalue );
