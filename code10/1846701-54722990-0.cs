    internal class MainViewModel : BindableBase
    {
        public MainViewModel( IMaskingCreationViewModelFactory maskingCreationViewModelFactory, IEnumerable<ITabBehavior> tabBehaviors )
        {
            foreach (var tabBehavior in tabBehaviors)
                TabItemCollection.Add( maskingCreationViewModelFactory.Create( tabBehavior ) );
            SelectedTabItem = TabItemCollection.FirstOrDefault();
        }
        public ObservableCollection<MaskingCreationViewModel> TabItemCollection { get; } = new ObservableCollection<MaskingCreationViewModel>();
        public MaskingCreationViewModel SelectedTabItem { get => _selectedTabItem; set => SetProperty( ref _selectedTabItem, value ); }
        private MaskingCreationViewModel _selectedTabItem;
    }
