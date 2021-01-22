    public class MyViewModel : INotifyPropertyChanged, INotifyCollectionChanged
    {
        public MyViewModel(DataModel dataModel) { ... }
    }
    
    public class MyController
    {
        public MyController(MainWindow mainWindow, ViewModel viewModel) { ... }
        public ViewModel { get { return _viewModel; } }
        public ICommand DisplayChild { ... }
    }
