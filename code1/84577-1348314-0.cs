    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChanged;
        public void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(propertyName);
        }
        public virtual string MyProperty { get; set; }
        public virtual string MyProperty2 { get; set; }
    }
