    class Data
    {
        public Data(int answerId, string answerContent, int? questionReadingId, int? questionListeningId, bool isCorrected)
        {
            AnswerId = answerId;
            AnswerContent = answerContent;
            QuestionReadingId = questionReadingId;
            QuestionListeningId = questionListeningId;
            IsCorrected = isCorrected;
        }
        public int AnswerId { get; set; }
        public string AnswerContent { get; set; }
        public int? QuestionReadingId { get; set; }
        public int? QuestionListeningId { get; set; }
        public bool IsCorrected { get; set; }
    }
