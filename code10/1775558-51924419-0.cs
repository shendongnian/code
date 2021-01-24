    private NavigationItems _SelectedNavigationItem;
        public NavigationItems SelectedNavigationItem
        {
            get { return _SelectedNavigationItem; }
            set
            {
                if (_SelectedNavigationItem != value)
                {
                    _SelectedNavigationItem = value;
                    NavigateToPage(value);   
                }
            }
        }
