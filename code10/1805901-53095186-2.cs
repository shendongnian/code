    @{bool IsIE = false ;
    if (Request.Browser.Type.ToUpper().Contains("IE"))
    { 
        IsIE = true;
    }
    
    }
    @if (IsIE)
    {
        // Your Razor here
    }
    else
    {
        //  Your Razor here
    }
