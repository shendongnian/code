    public class CustomBindingList<T> : BindingList<T>
    {
       public void Move(T item, int index)
       {
          bool raiseListChangedEvents = this.RaiseListChangedEvents;
          try
          {
             this.RaiseListChangedEvents = false;
             int oldIndex = this.IndexOf(item);
             this.Remove(item);
             this.InsertItem(index, item);
    
             this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemMoved, index, oldIndex);
          }
          finally
          {
             this.RaiseListChangedEvents = raiseListChangedEvents;
          }
       }
    }
