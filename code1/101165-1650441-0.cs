    RadioButtonQuestionControl: QuestionControl {
        // Contains radio-button rendering logic
    }
    
    CheckboxListQuestionControl: QuestionControl {
        // Contains checkbox list rendering logic
    }
    
    QuestionControlFactory {
        public QuestionControl CreateQuestionControl(Question question) {
           // Switches on Question.Type to produce the correct control
        }
    }
