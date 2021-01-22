    public static List<WhatHappened> DoStuff()
    {
        List<del> CheckValues = new List<del>();
        
        List<WhatHappened> returnValue = new List<WhatHappened>();
        
        CheckValues.Add(method1);
        CheckValues.Add(method2);
        
        return CheckValues
                   .Select(dlg => dlg())
                   .Where( res => res != WhatHappened.Nothing)
                   .ToList();
    }
