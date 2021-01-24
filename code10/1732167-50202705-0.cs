    public class UserModel
    {
        public string Email { get; set; }
        public List<Answer> SelectedAnswers { set; get; }
    }
    public class Answer
    {
        public int QuestionId { set; get; }
        public int AnswerId { set; get; }
    }
