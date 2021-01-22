    public class Base : INotifyPropertyChanged
    {
        protected PropertyChangedEventHandler propertyChanged;
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { propertyChanged += value; }
            remove { propertyChanged -= value; }
        }
    }
    public class Derived : Base
    {
        string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                propertyChanged.Raise(() => Name);
            }
        }
    }
