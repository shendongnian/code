     public interface ICanDoSomething
     
     public abstract class AbstractCanDoSomething
     {
         public class OperationResult
         {
              public bool SomeValue { get; set; }
              public int SomeOherVAlue { get; set; }
         }
         public abstract OperationResult DoMyThing();
     }
