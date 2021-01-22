    class ConfigViewModel:INotifyPropertyChanged
    {
        public XElement Xml { get; private set;}
        
        //example of persistence infrastructure
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void Load(string fileName)
        {
            Xml = XElement.Load(fileName);
            PropertyChanged(this, new PropertyChangedEventArgs("Xml"));
        }
        public void Save(string fileName)
        {
            Xml.Save(fileName);
        }
    }
