    public class PersonValueHolder
    {
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public bool HasCollegeDegree { get; set; }
    }
    public class SyncronicityHandler<T>
    {
         private object locker = new object();
    
         private T valueHolder;
    
         public SynchronicityHandler(T theValueHolder)
         {
              this.valueHolder = theValueHolder;
         }
    
         public void WorkWithValueHolderSafely(Action<T> yourAction)
         {
              lock(locker)
              {
                   yourAction(valueHolder);
              }
         }
    }
