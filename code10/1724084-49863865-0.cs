    public class MyViewModel : BindableBase
    {
        private ParentObject _parent;
        public ParentObject Parent
        {
            get { return _parent; }
            set
            {
                if (_parent != null)
                {
                   _parent.PropertyChanged -= OnChildPropertyChanged;
                }
                _parent = value;
                RaisePropertyChanged(nameof(Parent);
                if (value != null)
                {
                   value.PropertyChanged += OnChildPropertyChanged;
                }
                // SomeMethod(Parent);
            }
        }
        public void SomeMethod(ParentObject obj) { ... }
        private void OnChildPropertyChanged(object sender, PropertyChangedEventArgs args) 
        {
            SomeMethod(Parent);
        }
    }
