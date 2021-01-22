    private readonly object controlNameChangedSync = new object();
    event ControlNameChangeHandler IProcessBlock.OnControlNameChanged
    {
      add
      {
        lock (controlNameChangedSync)
        {
          ControlNameChanged += value;
        }
      }
      remove
      {
        lock (controlNameChangedSync)
        {
          ControlNameChanged -= value;
        }
      }
    }
