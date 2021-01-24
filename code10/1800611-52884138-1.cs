        public class BindableBaseBusinessObject: DependencyObject,INotifyPropertyChanged
        {
            protected virtual void SetProperty<T>(ref T member, T val,[CallerMemberName] string propertyName = null)
            {
               if (object.Equals(member, val)) return;
               member = val;
               PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
              PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
    
            /*
                public static implicit operator BindableBase(CustomerListViewModel v)
                {
                  throw new NotImplementedException();
                }
            */
    
        }
 
