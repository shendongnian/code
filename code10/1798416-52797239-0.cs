    public class Submission
    {
       [JsonConverter(typeof(QuestionConverter))]
       List<IQuestion> Questions 
    }
    
    public interface IQuestion
    {
       public string Id { get; set; }
    }
    public class SingleChoiceQuestion : IQuestion
    {
        public string Id { get; set; }
    
        public string Answer { get; set; }
    }
    
    public class MultipleChoiceQuestion : IQuestion
    {
        public string Id { get; set; }
        public List<string> SelectedAnswers { get; set; }
    }
    
    // this lets you nest questions inside questions (or just multiple single choice questions)
    public class RecursiveQuestion : IQuestion
    {
        public string Id { get; set; }
        public List<IQuestion> Question { get; set; }
    }
