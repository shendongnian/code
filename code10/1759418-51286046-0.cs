    public class ObservableExaminationSettingModel : INotifyPropertyChanged
        {
            public string MaxReactionTime { get; set; }
    
            private bool _isMaxReactionTimeCorrect ;
            public bool IsMaxReactionTimeCorrect 
            {
                get
                {
                    return _selected;
                }
                set
                {
                    _selected = value;
                    RaisePropertyChanged("IsMaxReactionTimeCorrect");
                }
            }
            public ObservableCollection<ValidatedExaminationAnswerModel> CorrectAnswers { get; set; } = new ObservableCollection<ValidatedExaminationAnswerModel>();
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
