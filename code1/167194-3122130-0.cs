    namespace DeleteMeQuestion.Models
    {
        public class QuizModel
        {
            public int ParentQuestionId { get; set; }
            public int QuestionId { get; set; }
            public string QuestionDisplayText { get; set; }
            public List<Response> Responses { get; set; }
            [Range(1,999, ErrorMessage = "Please choose a response.")]
            public int SelectedResponse { get; set; }
        }
        public class Response
        {
            public int ResponseId { get; set; }
            public int ChildQuestionId { get; set; }
            public string ResponseDisplayText { get; set; }
        }
    }
