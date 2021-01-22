    public class ViewModelBase : INotifyPropertyChanged
    {
        protected bool Set<T>(ref T backingField, T value, [CallerMemberName] string propertyname = null)
        {
            // Check if the value and backing field are actualy different
            if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return false;
            }
            // Setting the backing field and the RaisePropertyChanged
            backingField = value;
            RaisePropertyChanged(propertyname);
            return true;
       }
    }
