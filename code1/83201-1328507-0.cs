    private object _lock = new object()
    private bool _initialized;
    
    public T()
    {
       lock(_lock)
       {
          if(!_initialized)
          {
             try
             {
               //Do static stuff here
             }
             catch(Exception ex_)
             {
               //Handle exception
             }
          } 
       }
    }
