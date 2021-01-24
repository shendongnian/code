    public sealed class PopUpViewModel : Screen
    {
        private readonly BindableCollection<ITabItem> _tabItems = new BindableCollection<ITabItem>();
        private IScreen _selectedTab;
        public PopUpViewModel()
        {
            DisplayName = "Popup";
            TabItems.Add(new TabItem1ViewModel());
            TabItems.Add(new TabItem2ViewModel());
            SelectedTab = TabItems.FirstOrDefault();
        }
        public BindableCollection<ITabItem> TabItems
        {
            get => _tabItems;
            set
            {
                if(_tabItems == null)
                    return;
                _tabItems.Clear();
                _tabItems.AddRange(value);
                NotifyOfPropertyChange(() => TabItems);
            }
        }
        public IScreen SelectedTab
        {
            get => _selectedTab;
            set
            {
                _selectedTab = value;
                NotifyOfPropertyChange();
            }
        }
    }
