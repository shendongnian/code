    public class TestClass : INotifyPropertyChanged
    {
        private DateTime m_testDateTime = DateTime.Now;
        public DateTime TestDateTime
        {
            get { return m_testDateTime; }
            set
            {
                m_testDateTime = m_testDateTime.Date.Add(value.TimeOfDay);
                PropertyChanged(this, new PropertyChangedEventArgs("TestDateTime"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = (t, e) => {};
    }
