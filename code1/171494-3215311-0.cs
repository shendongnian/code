    class PartViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        public PartClass Data { get; set; }
        public String SomeVMProperty
        {
            get { return Data.SomeProperty; }
            set
            {
                if (Data.SomeProperty != value)
                    Data.SomeProperty = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("SomeVMProperty"));
            }
        }
    }
    class PartClass
    {
        public string SomeProperty { get; set; }
    }
