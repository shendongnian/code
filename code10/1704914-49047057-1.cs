    class QuestionAndAnswer {
        public string Question { get; set; } 
        public string Answer { get; set; }
    }
    private List<QuestionAndAnswer> _currentQuestions; // create this list when loading everything
    private int _currentQuestionIndex = 0; // points to which element/index in the list contains the question shown on screen
    // call this once after you have loaded _currentQuestions with your data
    public void ShowCurrentQuestion() { 
        var currQuestion = _currentQuestion[_currentQuestionIndex];
        computerQuestionLabel.Text = currQuestion.Question;
        answerTextBox.Text = "";
    }
    // call this from whichever event handler means that the user has
    // submitted an answer - an Answer button's Click event, maybe
    // answerTextBox's KeyPress event or something else.
    public void CheckForAnswer() {
        var currentAnswer = answerTextBox.Text;
        var currQuestion = _currentQuestion[_currentQuestionIndex];
        if (currQuestion.Answer == currentAnswer) { // correct
            var nextQuestionIndex = _currentQuestionIndex + 1;
            if (nextQuestionIndex == _currentQuestion.Count) { 
                // all questions answered! do the appropriate thing
            } else {
                // still questions left, show the next one
                _currentQuestionIndex = nextQuestionIndex;
                ShowCurrentQuestion();
            }
        } else {
            // wrong answer; the question that needs to be shown is 
            // already shown, you can handle "stop" or other things here
        }
    }
