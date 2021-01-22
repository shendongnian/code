    public class Question : INotifyPropertyChanged
    {
        private string m_Answer;
        public string Answer
        {
            get { return m_Answer; }
            set
            {
                if (m_Answer != value)
                {
                    m_Answer = value;
                    FirePropertyChanged("Answer");
                }
            }
        }
        private List<string> m_AnswerDomain;
        public List<string> AnswerDomain
        {
            get { return m_AnswerDomain; }
            set
            {
                if (m_AnswerDomain != value)
                {
                    m_AnswerDomain = value;
                    FirePropertyChanged("AnswerDomain");
                }
            }
        }
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        private void FirePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
