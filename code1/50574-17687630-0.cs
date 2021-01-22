    private readonly object eventMutex = new object();
    private event EventHandler _onEvent = null;
    public event EventHandler OnEvent
    {
      add
      {
        lock(eventMutex)
        {
          _onEvent += value;
        }
      }
      remove
      {
        lock(eventMutex)
        {
          _onEvent -= value;
        }
      }
    }
    private void HandleEvent(EventArgs args)
    {
      lock(eventMutex)
      {
        if (_onEvent != null)
          _onEvent(args);
      }
    }
