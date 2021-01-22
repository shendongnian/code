    public enum Colors
    {
        Red,
        Orange,
        Green
    }
    
    ...
    
    public bool IsRed(Colors c)
    {
        if (c == Colors.Red)
            return true;
        else
            return false;
    }
