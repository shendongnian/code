    if (Request.Browser.Type.Contains("Firefox")) // replace with your check
    {
        ...
    } 
    else if (Request.Browser.Type.ToUpper().Contains("IE")) // replace with your check
    {
        if (Request.Browser.MajorVersion  < 7)
        { 
            DoSomething(); 
        }
        ...
    }
    else { }
