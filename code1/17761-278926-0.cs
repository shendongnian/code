    private object _myDateTimeLock = new object();
    private DateTime _myDateTime;
    
    public DateTime MyDateTime{
      get{
        lock(_myDateTimeLock){return _myDateTime;}
      }
      set{
        lock(_myDateTimeLock){_myDateTime = value;}
      }
    }
