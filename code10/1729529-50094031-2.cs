    for (int i = 0; i < objA?.Length; i++)
    {
        ExecuteCode(objA[i]?.Any);
    }    
...
    static void ExecuteCode(YourTypeHere[] children)
    {
        for (int i = 0; i < children?.Length; i++)
        {
            if (children[i]?.Name?.ToLower() == "code")
            {
                //some code
            }
        }
    }
