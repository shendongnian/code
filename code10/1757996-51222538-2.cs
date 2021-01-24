      public class MyItem : INotifyPropertyChanged
      {
        private int m_value;
        public int Value
        {
          get { return m_value; }
          set
          {
            m_value = value;
            OnPropertyChanged("Value");
            OnPropertyChanged("AsString");
          }
        }
    
        public string AsString
        {
          get
          {
            return ToString();
          }
        }
    
        private int m_answerStatus;
        public int AnswerStatus
        {
          get { return m_answerStatus; }
          set
          {
            m_answerStatus = value;
            OnPropertyChanged("AnswerStatus");
            OnPropertyChanged("AsString");
          }
        }
    
        public void SwapStatus()
        {
          AnswerStatus = m_answerStatus == 1 ? 2 : 1;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    
        public override string ToString()
        {
          return $"MyItem: {Value} {AnswerStatus}";
        }
      }
