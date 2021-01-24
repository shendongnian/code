    public class Base
    {
        public int Id { get; set; }
    }
    public class Unit : Base
    {
        public string UnitData { get; set; }
    }
    public class Component : Base
    {
        public string ComponentData { get; set; }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Base> Objects { get; }
            = new ObservableCollection<Base>();
        private Base selectedObject;
        public Base SelectedObject
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
