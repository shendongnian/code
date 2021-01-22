    public static string MakeString(this object o)
    { return o == null ? "null" : o.ToString();  }
    
    // elsewhere:
    object o = null;
    Console.WriteLine(o.MakeString());
