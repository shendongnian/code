    public abstract class Operation<T1, T2, TItem>
      where T1: Data<TItem> 
      where T2: Data<TItem> 
    {
    
      public abstract T2 Run (T1 input);
    }
