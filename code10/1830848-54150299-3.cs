    class ItemsViewModel : BaseViewModel
        {
            private bool _checked;
            private string _name;
    
            public bool Checked
            {
                get => _checked;
                set
                {
                    if (value == _checked) return;
    
                    _checked = value;
                    OnPropertyChanged("Checked");
                }
            }
    
            public string Name
            {
                get => _name;
                set
                {
                    if (value == _name) return;
    
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
