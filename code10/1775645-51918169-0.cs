    public class PollQuestion
    {
        public string QuestionText { get; set; }
    }
    
    public class RootObject
    {
        public string Question { get; set; }
        public List<PollQuestion> PollQuestions { get; set; }
    }
