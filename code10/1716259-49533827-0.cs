    public class ExampleModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> names = new ObservableCollection<string>();
        public ObservableCollection<string> Names
        {
            get => names;
            set
            {
                names = value;
                //Only called if I change the collection reference i.e. make a new ObservableCollection or assign it to another exising reference.
                //Not called adding or removing items from existing collection.
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Names)));
            }
        }
    }
....
    public class ExampleViewModel : INotifyPropertyChanged
    {
        private readonly ExampleModel ExampleModel;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> names = new ObservableCollection<string>();
        public ExampleViewModel()
        {
            ExampleModel = new ExampleModel();
            ExampleModel.PropertyChanged += ExampleModel_PropertyChanged;
            Names = ExampleModel.Names;
            if (Names != null) Names.CollectionChanged += Names_CollectionChanged;
        }
        private void ExampleModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(ExampleModel.Names):
                    //Here we reassign the entire collection if it changes.
                    if (Names != null) Names.CollectionChanged -= Names_CollectionChanged;
                    Names = ExampleModel.Names;
                    if (Names != null) Names.CollectionChanged += Names_CollectionChanged;
                    break;
            }            
        }
        private void Names_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (var item in e.OldItems)
                Names.Remove((string)item);
            foreach (var item in e.NewItems)
                Names.Add((string)item);
        }
        public ObservableCollection<string> Names
        {
            get { return names; }
            set
            {
                names = value;
                //Only called if I change the collection reference i.e. make a new ObservableCollection or assign it to another exising reference.
                //Not called adding or removing items from existing collection.
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Names)));
            }
        }
    }
