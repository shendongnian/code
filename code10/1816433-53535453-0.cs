     public class Question
    {
        public string q { get; set; }
        public List<answersList> answersList { get; set; }
        public string typeOfQuestion { get; set; }
        public int CorrectAnswer { get; set; }
    }
    public class answersList
    {
        public string answer { get; set; }
        public string code { get; set; }
    }
