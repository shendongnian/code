    void Main()
    {
        var questions = new List<Question>();
        questions.Add(new Question("2+2?", new List<string> { "4", "5", "6" }, "4"));
        questions.Add(new Question("2*2?", new List<string> { "1", "4", "8" }, "4"));
        questions.Add(new Question("2/2?", new List<string> { "0", "1", "2" }, "1"));
        
        var json = JsonConvert.SerializeObject(questions, Newtonsoft.Json.Formatting.Indented);
        Console.WriteLine(json);
    }
    
    // Define other methods and classes here
    public class Question
    {
        public string question;
        public List<string> answers;
        public string correct;
    
        public Question(string question, List<string> answers, string correct)
        {
            this.question = question;
            this.answers = answers;
            this.correct = correct;
        }
    }
