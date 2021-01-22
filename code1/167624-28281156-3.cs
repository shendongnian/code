    public class ObservableStack<T> : Stack<T>, INotifyPropertyChanged, INotifyCollectionChanged
    {
      public ObservableStack(IEnumerable<T> collection) : base(collection) {}
      public ObservableStack() { } 
     
      public event PropertyChangedEventHandler PropertyChanged = delegate { };
      public event NotifyCollectionChangedEventHandler CollectionChanged = delegate { };
     
      protected virtual void OnCollectionChanged(NotifyCollectionChangedAction action, List<T> items, int? index = null)
      {
        if (index.HasValue)
        {
            CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, items, index.Value));
        }
        else
        {
            CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, items));
        }
         OnPropertyChanged(GetPropertyName(() => Count));
      }
     
      protected virtual void OnPropertyChanged(string propName)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propName));
      }
     
      public new virtual void Clear()
      {
        base.Clear();
        OnCollectionChanged(NotifyCollectionChangedAction.Reset, null);
      }
     
      public new virtual T Pop()
      {
        var result = base.Pop();
        OnCollectionChanged(NotifyCollectionChangedAction.Remove, new List<T>() { result }, base.Count);
        return result;
      }
        
      public new virtual void Push(T item)
      {
        base.Push(item);
        OnCollectionChanged(NotifyCollectionChangedAction.Add, new List<T>() { item }, base.Count - 1);
      }   
    
      public new virtual void TrimExcess()
      {
        base.TrimExcess();
        OnPropertyChanged(GetPropertyName(() => Count));
      }
String GetPropertyName<TValue>(Expression<Func<TValue>> propertyId)
{
   return ((MemberExpression)propertyId.Body).Member.Name;
}
    }</code></pre>
