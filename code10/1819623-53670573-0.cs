    public class ChatListModel : ChatListViewModel
    {
        private static int idCount = 0;
        public ChatListModel()
        {
            Items = new ObservableCollection<ChatListItemViewModel>();
            AddMessage("p", "m");
        }
        public void AddMessage(string p, string m)
        {
            ChatListItemViewModel newItem = new ChatListItemViewModel
            {
                Pseudo = p,
                Message = m,
                Id = idCount
            };
            newItem.PropertyChanged += NewItem_PropertyChanged;
            Items.Add(newItem);
            idCount++;
        }
        private void NewItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ChatListItemViewModel removedItem = (ChatListItemViewModel)sender;
            removedItem.PropertyChanged -= NewItem_PropertyChanged;
            Items.Remove(removedItem);
            idCount--;
        }
        public ObservableCollection<ChatListItemViewModel> Items { get; }
    }
    public class ChatListItemViewModel : BaseViewModel
    {
        public string Pseudo { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
        private bool _isDeleted;
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; OnPropertyChanged(nameof(IsDeleted)); }
        }
        public ChatListItemViewModel()
        {
            DeleteCommand = new RelayCommand(_ => true, _ => IsDeleted = true);
        }
        public ICommand DeleteCommand { get; }
    }
