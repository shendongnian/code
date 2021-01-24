    public class TestItem : ObservableObject
    {
        public TestItem(string a_name)
        {
            m_name = a_name;
        }
        private string m_name;
        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
                RaisePropertyChanged("Name");
            }
        }
        private bool m_isSelected;
        public bool IsSelected
        {
            get
            {
                return m_isSelected;
            }
            set
            {
                m_isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }
    }
