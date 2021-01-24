    using Prism.Mvvm;
    public class MyVM : BindableBase
    {
        public ObservableCollection<MyModel> MyModelCollection
        {
           get {return _myModelCollection;}
           set {SetProperty(ref _myModelCollection);}
        }
        private ObservableCollection<MyModel> _myModelCollection;
    }
