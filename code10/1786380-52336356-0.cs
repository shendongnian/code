        public class SurveyList
        {
            [JsonProperty("title")]
            public string SurveyTtitle { get; set; }
            [JsonProperty("questions")]
            public List<QuestionList> Questions { get; set; }
        }
        public class QuestionList
        {
            [JsonProperty("question")]
            public string QuestionText { get; set; }
            [JsonProperty("questionId")]
            public string QuestionCode { get; set; }
        }
