    public abstract class Observable : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
      
       protected bool SetPropertyAndNotifyIfNeeded<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
       {
          if (EqualityComparer<T>.Default.Equals(field, value))
             return false;
          field = value;
          NotifyPropertyChanged(propertyName);
          return true;
       }    
       protected void NotifyPropertyChanged([CallerMemberName]string name=null)
       {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
       }
    }
