    public class VmMainContainer : INotifyPropertyChanged
    {
        private object selectedItemTreeViewSs = new object();
        private ObservableCollection<object> selectedItemsTreeViewSs = new ObservableCollection<object>();
        private ObservableCollection<VmItem> itemsTreeViewSs = new ObservableCollection<VmItem>();
    
     public object SelectedItemTreeViewSs
            {
                get
                {
                    return selectedItemTreeViewSs;
                }
                set
                {
                    selectedItemTreeViewSs = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItemTreeViewSs)));
                }
            }
    
    public ObservableCollection<object> SelectedItemsTreeViewSs
            {
                get
                {
                    return selectedItemsTreeViewSs;
                }
                set
                {
                    selectedItemsTreeViewSs = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItemsTreeViewSs)));
                }
            }
    
     public ObservableCollection<VmItem> ItemsTreeViewSs
            {
                get { return itemsTreeViewSs; }
                set
                {
                    itemsTreeViewSs = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ItemsTreeViewSs)));
                }
            }
        }
