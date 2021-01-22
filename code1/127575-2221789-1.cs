    if (Request.Browser.Type.Contains("FF") // replace with your check
    {
    .....
    } 
    else if (Request.Browser.Type.Contains("IE") // replace with your check
    {
       if (Request.Browser.MajorVersion  < 7)
       {   DoSomething(); }
    ...
    }
    else { }
