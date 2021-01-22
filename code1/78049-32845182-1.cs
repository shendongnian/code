            private ICommand _selectedItemChangedCommand;
            public ICommand SelectedItemChangedCommand
            {
                get
                {
                    if (_selectedItemChangedCommand == null)
                        _selectedItemChangedCommand = new RelayCommand(args => SelectedItemChanged(args));
                    return _selectedItemChangedCommand;
                }
            }
    
            private void SelectedItemChanged(object args)
            {
                //Cast your object
            }
