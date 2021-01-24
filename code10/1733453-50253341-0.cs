    private ObservableCollection<StateFilter> _stateFilters;
            public ObservableCollection<StateFilter> StateFilters
            {
                get { return _stateFilters; }
                set
                {
                    _stateFilters = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("StateFilters"));
                }
            }
    
            private bool _stateFilter;
            public bool StateFilter
            {
                get { return _stateFilter; }
                set
                {
                    _stateFilter = value;
    
                    ObservableCollection<StateFilter> local = new ObservableCollection<StateFilter>();
    
                    foreach (var filter in StateFilters)
                    {
                        filter.IsChecked = _stateFilter;
                        local.Add(filter);
    
                    }
                    StateFilters = local;
    
                    PropertyChanged(this, new PropertyChangedEventArgs("StateFilter"));
    
                }
            }
