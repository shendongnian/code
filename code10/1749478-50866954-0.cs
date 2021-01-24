    public class MainViewModel : BindableBase
    {
        public ObservableCollection<SubViewModel> SubViewModels { get; }
        public MainViewModel()
        {
            SubViewModels = new ObservableCollection<SubViewModel>();
            SubViewModels.CollectionChanged += SubViewModels_CollectionChanged;
        }
        private void SubViewModels_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach(var subVM in e.NewItems.Cast<SubViewModel>())
                {
                    subVM.PropertyChanged += SubViewModel_PropertyChanged;
                }
            }
            // TODO: Unsubscribe to SubViewModels that are removed in collection to avoid memory leak.
        }
        private void SubViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SubViewModel.IsChecked):
                    // TODO: Do your thing here...
                    break;
            }
        }
    }
    public class SubViewModel : BindableBase
    {
        private bool _isChecked;
        public bool IsChecked
        {
            get => _isChecked;
            set => SetProperty(ref _isChecked, value);
        }
    }
