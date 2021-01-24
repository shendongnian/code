    class NewClass : Reply {
        private Comment comment;
        private Answer answer;
    
        NewClass() {
            comment = new Comment();
            answer = new Answer();
        }
    
        void CommentMethod() {
            comment.CommentMethod();
        }
    
        void AnswerMethod() {
            answer.AnswerMethod();
        }
    }
