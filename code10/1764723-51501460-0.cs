    public class Question
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Required] [MaxLength(255)] public string Text { get; set; }
        [MaxLength(255)] public string FrameText { get; set; }
        public int Order { get; set; }
        public QuestionType Type { get; set; }
        //explicitly define foreign key as a nullable int.
        //EF should be clever enough to use DefaultAnswerId as the 
        //foreign key to the DefaultAnswer Property, but telling it 
        //explicitly won't do any harm.
        [ForeignKey("DefaultAnswer")]
        public int? DefaultAnswerId { get; set; }
        public DefaultAnswer DefaultAnswer { get; set; }
        public IList<Answer> Answers { get; set; }
    }
