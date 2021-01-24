    public enum QuestionType
    {
        Scenario,
        Step
    }
    public class Question
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Required] [MaxLength(255)]
        public string Text { get; set; }
        [MaxLength(255)]
        public string FrameText { get; set; }
        public int Order { get; set; }
        public QuestionType Type { get; set; }
        public DefaultAnswer DefaultAnswer { get; set; }
        public IList<Answer> Answers { get; set; }
    }
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }
        public int Order { get; set; }
        public Scenario Scenario { get; set; }
        public Question Question { get; set; }
        //commented these out for the sake of this
        //example
       /*public IList<Formula> Formulas { get; set; }
        public IList<Image> Images { get; set; }*/
    }
    public class DefaultAnswer
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
        public Question Question { get; set; }
    }
