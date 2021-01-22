    public class SomeThing
    {
          public string Name {get; set;}
    
          public override GetHashCode()
          {
              return Name.GetHashcode();
          }
    
          public override Equals(object other)
          {
               SomeThing = other as Something;
               if( other == null ) return false;
               return this.Name == other.Name;
          }
    }
