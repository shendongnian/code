    public class A
    {
      private string s1;
      public virtual string S1
      { 
        get { return this.s1; }
      }
    }
    
    public class B : A
    {
      private string myString = "default";
      public override string S1
      {
        get
        {
          return this.myString;
        }
      } 
    }
