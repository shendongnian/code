    public class CustomControl : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
    
        private string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                if (_value == value) return;
    
                _value = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Value"));
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    
        internal virtual void OnSiblingInPagePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
          
        }
    }
    
    public class CustomControlObservableColletion : ObservableCollection<CustomControl>
    {
        // Required because, by default, it is not possible to find out which items
        // have been cleared when the CollectionChanged event is fired after a .Clear() call.
        protected override void ClearItems()
        {
            foreach (var item in Items.ToList())
                Remove(item);
        }
    
    }
    
    public class Page
    {
        public IList<CustomControl> Controls { get; private set; }
    
        public Page()
        {
            var controls = new CustomControlObservableColletion();
            controls.CollectionChanged += OnCollectionChanged;
            Controls = controls;
        }
    
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    RegisterControls(e.NewItems);
                    break;
    
                case NotifyCollectionChangedAction.Replace:
                    RegisterControls(e.NewItems);
                    DeRegisterControls(e.OldItems);
                    break;
    
                case NotifyCollectionChangedAction.Remove:
                    DeRegisterControls(e.OldItems);
                    break;
            }
        }
    
        private void RegisterControls(IList controls)
        {
            foreach (CustomControl control in controls)
                control.PropertyChanged += OnControlPropertyChanged;
        }
    
        private void DeRegisterControls(IList controls)
        {
            foreach (CustomControl control in controls)
                control.PropertyChanged -= OnControlPropertyChanged;
        }
    
        private void OnControlPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            foreach (var control in Controls.Where(c => c != sender))
                control.OnSiblingInPagePropertyChanged(sender, e);
        }
    }
