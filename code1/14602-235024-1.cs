    public static bool IsNull(this object input)
    {
        input == null ? return true : return false;
    }
    
    public void Main()
    {
       object x = new object();
       if(x.IsNull)
       {
          //do your thing
       }
    }
