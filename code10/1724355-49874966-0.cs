    public class Answer
    {
        public string Questions { get; set; }
        public string Answers { get; set; }
        public string Results { get; set; }
        
        public Answer(string text)
        {
             Answers = text;
        }
    
        public Answer(string question, string answer, string results)
        {
             Questions = question;
             Answers = answer;
             Results = results;
        }
    }
