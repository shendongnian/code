    protected override void OnListChanged(ListChangedEventArgs e)
    {
      // SynchronizationContext ctx = SynchronizationContext.Current;
      if (ctx == null)
      {
        BaseListChanged(e);
      }
      else if(e.ListChangedType == ListChangedType.ItemChanged)
      {
        ctx.Post(delegate { BaseListChanged(e); }, null);
      }
      else
      {
        ctx.Send(delegate { BaseListChanged(e); }, null);
      }
    }
