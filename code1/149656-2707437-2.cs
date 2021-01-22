    public class Platform : INotifyPropertyChanged
    {
        private string m_name;
        private bool m_selected;
        public Platform(string name)
        {
            m_name = name;
            m_selected = false;
        }
        public string Name
        {
            get { return m_name; }
            set
            {
                m_name = value;
                OnPropertyChanged("Name");
            }
        }
        public bool Selected
        {
            get { return m_selected; }
            set
            {
                m_selected = value;
                OnPropertyChanged("Selected");
            }
        }
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
