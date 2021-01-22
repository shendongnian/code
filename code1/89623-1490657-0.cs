    public class myFormViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void InvokePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed != null) changed(this, new PropertyChangedEventArgs(propertyName));
        }
    
    
        private object _planeSelectedItem;
        public object PlaneSelectedItem
        {
            get { return _planeSelectedItem; }
            set
            {
                _planeSelectedItem = value;
                InvokePropertyChanged("PlaneSelectedItem");
            }
        }
    
        public IEnumerable<KeyValuePair<string, Geometry>> VisibleElements
        {
            get
            { 
               foreach(var slenderMember in PlaneSelectedItem.VisibleElements)
                {
                    yield return new KeyValuePair<string, Geometry>(slenderMember.AsString, ToGeometry(slenderMember));
                }
            }
        }
    }
