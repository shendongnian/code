    private bool _eventHasSubscribers = false;
    private EventHandler<MyDelegateType> _myEvent;
    
    public event EventHandler<MyDelegateType> MyEvent
    {
       add 
       {
          if (_myEvent == null)
          {
             _myEvent += value;
          }
       }
       remove
       {
          _myEvent -= value;
       }
    }
