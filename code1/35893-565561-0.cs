    public class AnswerHistory : Answer {
        public AnswerHistory (Answer answer) {
            this.QuestionID = answer.QuestionID;
            this.Value = answer.Value;
            // ...
        }
    }
