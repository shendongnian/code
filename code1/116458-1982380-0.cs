    public class MyClass 
    {
    
       private List<string> _someList;
    
       public List<string> SomeString
       {
          get
          {
             if(_someList == null)
                _someList = new List<string>();
             return _someList;
          }
       }
    
    }
