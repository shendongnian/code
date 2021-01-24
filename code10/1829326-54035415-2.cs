    public class RawDataDTO
    {
        public Nullable<int> QuestionnaireId { get; set; }
        public Nullable<int> QuestionnaireGroupId { get; set; }
        public string QuestionnaireGroup { get; set; }
        public Nullable<int> QuestionTypeId { get; set; }
        public string QuestionType { get; set; }
        public List<Answer> Answer { get; set; }
        public Nullable<int> QuestionId { get; set; }
        public string Question { get; set; }
        public Nullable<int> ScaleId { get; set; }
        public string ScaleType { get; set; }
        public string Attribute { get; set; }
        public string AttributeValue { get; set; }
    }
