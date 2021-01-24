         public class QuestionModel
      {
        public int Id { get; set; }
        public string Question { get; set; }
    
        public List<SubQuestion> SubQuestions { get; set; }
    
        public List<Option> Options { get; set; }
      }
    public partial class SubQuestion
      {
        public int Id { get; set; }
        public int ParentQuestionId { get; set; }
        public string SubQuestion1 { get; set; }
    
        public virtual QuestionCategory QuestionCategory { get; set; }
      }
