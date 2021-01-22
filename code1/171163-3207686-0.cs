    public class Lazy<T> where T : new()
    { 
      private T value; 
 
      public bool IsValueCreated { get; private set;}
 
      public T Value 
      { 
        get 
        { 
            if (!IsValueCreated) 
            { 
                value = new T();
                IsValueCreated = true; 
            } 
            return value; 
        } 
      } 
    } 
