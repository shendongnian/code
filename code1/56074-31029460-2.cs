    public class MyViewModel : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool m_c1 = true;
	
        public bool C1 {
            get { return m_c1; }
            set {
                if (m_c1 != value) {
                    m_c1 = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("C1"));
                }
            }
        }
    }
