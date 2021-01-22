    public class SomeClass
    {
      private readonly IList<Action> _eventList = new List<Action>();
    
      ...
    
      public event Action OnDoSomething
      {
        add {
          _eventList.Add(value);
        }
        remove {
          _eventList.Remove(value);
        }
      }
    }
