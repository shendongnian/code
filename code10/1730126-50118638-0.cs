    public class QuestionBank
    {
        private string filePath = "test.csv";
        public List<Question> Questions = new List<Question>();
        public void GetAllQuestions()
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                Questions.Add(new Question
                {
                    Value = line
                });
            }
        }
    }
    public class Question
    {
        public string Value { get; set; }
    }
