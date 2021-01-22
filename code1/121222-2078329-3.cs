    public class CallsDelegateToDoSomething
    {      
       private Func<List<IBaseWindow>> m_windowLister; 
       public CallsDelegateToDoSomething(Func<List<IBaseWindow>> windowFunc)
       {
           m_windowLister = windowFunc;
       } 
    
       public List<IBaseWindow> GetWindowList() 
       {    
           if (windowLister == null) 
           {
               return new List<IBaseWindow>();
           }
    
           return m_windowLister();
       }
    }
