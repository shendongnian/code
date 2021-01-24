    public abstract class A
    {
      public virtual string X(string arg)
      {
        return "blarg";
      }
      public string X__A(string arg)
      {
        return X(arg);
      }
    }
    
    public class CommonProperties : A
    {
      public string foof { get; set;} = "widget";
      public string yay { get; set; }
    
      public override string X(string arg)
      {
        return "comarg";
      }
    }
    
    public class B : CommonProperties
    {
      public string UniqueProperty1 { get; set; }
    
      public override string X(string arg)
      {
        return X__A(arg);
      }
    }
