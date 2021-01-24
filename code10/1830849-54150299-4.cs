    public class MainViewModel : BaseViewModel
        {
            private string _selectedItemsString;
            private ObservableCollection<Items> _selectedItems;
    
    
    
            public ObservableCollection<Items> CollectionOfItems { get; set; }
    
            public ObservableCollection<Items> SelectedItems
            {
                get => _selectedItems;
                set
                {
                    _selectedItems = value;
                    OnPropertyChanged("SelectedItems");
                } 
            }
    
    
            public string SelectedItemsString
            {
                get => _selectedItemsString;
                set
                {
                    if (value == _selectedItemsString) return;
    
                    _selectedItemsString = value;
                    OnPropertyChanged("SelectedItemsString");
                }
            }
    
            public MainViewModel()
            {
                CollectionOfItems = new ObservableCollection<Items>();
                SelectedItems = new ObservableCollection<Items>();
    
                
    
    
                CollectionOfItems.Add(new Items { Checked = false, Name = "Item 1" });
                CollectionOfItems.Add(new Items { Checked = false, Name = "Item 2" });
                CollectionOfItems.Add(new Items { Checked = false, Name = "Item 3" });
    
            }
    
    
            public void FindCheckedItems()
            {
                CollectionOfItems.Where(x => x.Checked).ToList().ForEach(y => SelectedItems.Add(y));
            }
    
    
            public void ConcatSelectedElements()
            {
                SelectedItemsString = string.Join(", ", CollectionOfItems.Where(x => x.Checked).ToList().Select(x => x.Name)).Trim();
            }
        }
