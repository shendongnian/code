    public void RaiseEvent()
    {
      var handler = MyEvent;
      if(handler != null)
        handler(this, new EventArgs());
    }
