        private EntryItemViewModel _selectedItem;
        public EntryItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if(_selectedItem != value)
                {
                    _selectedItem = value;
                    IsSelected = !IsSelected;
                    OnPropertyChanged(nameof(SelectedItem));
                }                
            }
        }
