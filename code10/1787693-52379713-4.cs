    public class ViewModel1: INotifyPropertyChanged
        {
            public ViewModel1()
            {
                // Test Data.
                Items = new ObservableCollection<ItemViewModel>
                {
                    new ItemViewModel{ Code = "001", Description = "Paint" },
                    new ItemViewModel{ Code = "002", Description = "Brush" },
                    new ItemViewModel{ Code = "003", Description = "" }
                };
    
                EditCommand = new CustomCommand<ItemViewModel>(Edit, CanEdit);
            }
    
            public CustomCommand<ItemViewModel> EditCommand { get; }
    
            private bool CanEdit(ItemViewModel item)
            {
                return item?.Description != string.Empty;
            }
    
            private void Edit(ItemViewModel item)
            {
                Debug.WriteLine("Selected Item: {0} - {1}", item.Code, item.Description);
            }
    
            private ObservableCollection<ItemViewModel> _items { get; set; }
    
            public ObservableCollection<ItemViewModel> Items
            {
                get => _items;
                set
                {
                    _items = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
