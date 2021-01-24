    public class Answer
    {
        public string answerText { get; set; }
        public bool isCorrect { get; set; }
    }
    public class MyData
    {
        public string questionText { get; set; }
        public string imageUrl { get; set; }
        public List<Answer> answers { get; set; }
    }
    public class RootObject
    {
        public List<MyData> Data { get; set; }
    }
