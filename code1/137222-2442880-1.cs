    [NotifyPropertyChanged]
    [OnChildPropertyChanged]
    class WiringListViewModel
    {
        public IMainViewModel MainViewModel { get; private set; }
        public WiringListViewModel(IMainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }
        private void OnChildPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            if (sender == MainViewModel)
            {
                Debug.Print("Child is changing!");
            }
        }
    }
