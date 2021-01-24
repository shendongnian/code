    public class ListViewModel {
        public ObservableCollection<ListItemViewModel> Items => ...;
        public RelayCommand ChangeView1 => ...;
    }
    public class ListItemViewModel {
        public string Name => ...;
        public RelayCommand ChangeView2 => ...;
    }
