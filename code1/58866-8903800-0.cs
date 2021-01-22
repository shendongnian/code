    public interface ISomeInterface{
         String GetEntityType{ get; }
    }
    
    public abstract class BaseClass : ISomeInterface{
         public String GetEntityType { 
              get{ return this.GetType().ToString(); }
         }
    }
    
    public class ChildA : BaseClass {  }
    
    public class ChildB : BaseClass {  }
