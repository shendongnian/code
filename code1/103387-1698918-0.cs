    private void RaiseEventOnUIThread(Delegate theEvent, object[] args)
    {
      foreach (Delegate d in theEvent.GetInvocationList())
      {
        ISynchronizeInvoke syncer = d.Target as ISynchonizeInvoke;
        if (syncer = null)
        {
          d.DynamicInvoke(args);
        }
        else
        {
          syncer.BeginInvoke(d, args);  // cleanup omitted
        }
      }
    }
