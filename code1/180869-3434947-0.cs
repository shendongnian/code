    public class User
    {
        public int ID { get; }
        private string name;
        public string Name
        {
            get { return name; }
            set 
            {
                if(value != name)
                {
                    name = value; 
                    NotifyPropertyChanged("Name");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
