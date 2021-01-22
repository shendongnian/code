    public class UniqueAttribute<T> : ValidationAttribute  
    where T : DataContext{
    
        protected T Context { get; private set; }
    
      ...    
    
        }
