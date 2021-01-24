    public class Abc
    {
       public static void Method(string propertyName) { }
    }
    
    public class Def
    {
       public int Prop { get; }
    
       public void Method2()
       {
    #pragma warning disable CA1507 - use nameof
           Abc.Method("Prop");
    #pragma warning restore CA1507 - use nameof
       }
    }
