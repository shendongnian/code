    public class Data : INotifyPropertyChanged
    {
        // boiler-plate
        ...
        // props
        private string name;
        public string Name
        {
            get { return name; }
            set { SetField(ref name, value, "Name"); }
        }
    }
