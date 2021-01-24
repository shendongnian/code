    public class NamedObject
    {
        public string Name { get; set; }
    }
    public class Unit : NamedObject
    {
        public string UnitData { get; set; }
    }
    public class Component : NamedObject
    {
        public string ComponentData { get; set; }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<NamedObject> Objects { get; }
            = new ObservableCollection<NamedObject>();
        private NamedObject selectedObject;
        public NamedObject SelectedObject
        {
            get { return selectedObject; }
            set
            {
                selectedObject = value;
                PropertyChanged?.Invoke(this,
                   new PropertyChangedEventArgs(nameof(SelectedObject)));
            }
        }
    }
