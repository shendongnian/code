    public class MTObservableCollection<T> : ObservableCollection<T>
    {
       public override event NotifyCollectionChangedEventHandler CollectionChanged;
       protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
       {
          var eh = CollectionChanged;
          if (eh != null)
          {
             Dispatcher dispatcher = (from NotifyCollectionChangedEventHandler nh in eh.GetInvocationList()
                     let dpo = nh.Target as DispatcherObject
                     where dpo != null
                     select dpo.Dispatcher).FirstOrDefault();
    
            if (dispatcher != null && dispatcher.CheckAccess() == false)
            {
               dispatcher.Invoke(DispatcherPriority.DataBind, (Action)(() => OnCollectionChanged(e)));
            }
            else
            {
               foreach (NotifyCollectionChangedEventHandler nh in eh.GetInvocationList())
                  nh.Invoke(this, e);
            }
         }
      }
    }
