    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using TestWpfApplication.Annotations;
    
    namespace TestWpfApplication
    {
        internal class MainWindowViewModel : INotifyPropertyChanged
        {
            private RelayCommand _yesCommand;
            private RelayCommand _noCommand;
            private int _questionIndex;
            private string _questionText;
            private List<string> _questions;
    
            public MainWindowViewModel()
            {
                _questions = new List<string>
                {
                    "Name your favourite football team",
                    "Do you like F1",
                    "Mothers Maiden Name",
                    "Random Question"
                };
    
                QuestionText = _questions[_questionIndex];
    
                _yesCommand = new RelayCommand(o => Yes());
                _noCommand = new RelayCommand(o => No());
            }
    
            public string QuestionText
            {
                get => _questionText;
                set
                {
                    _questionText = value;
                    OnPropertyChanged(nameof(QuestionText));
                }
            }
    
            public ICommand YesCommand => _yesCommand;
    
            public ICommand NoCommand => _noCommand;
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            private void Yes()
            {
                // Logic for storing the answer to the question
                MoveToNextQuestion();
            }
    
            private void No()
            {
                // Logic for storing the answer to the question
                MoveToNextQuestion();
            }
    
            private void MoveToNextQuestion()
            {
                if (_questionIndex < _questions.Count - 1)
                {
                    QuestionText = _questions[++_questionIndex];
                }
            }
        }
    }
