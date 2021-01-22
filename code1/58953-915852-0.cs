    using System.Reflection;    
    public int X(Bar bar, FieldInfo x)
    {
        return (int)x.GetValue(bar) * 2;
    }
