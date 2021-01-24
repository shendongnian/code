    public class IndustryFilters : INotifyPropertyChanged {
        private _isAllChecked;
  
        public IsAllChecked {
            get {return _isAllChecked;}
            set{
                _isAllChecked = value;
                foreach(var filter in Filters) { 
                    filter.IsChecked = value;
                }
                PropertyChanged(...);
            }
        }
        public ObservableCollection<IndustryFilter> Filters
        {
            get { return _industryFilters; }
            set
            {
                _industryFilters = value;
                PropertyChanged(this, new propertyChangedEventArgs("IndustryFilters"));
            }
        }
    }
