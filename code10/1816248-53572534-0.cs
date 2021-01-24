    [Serializable]
    public class Question
    {
        public int id;
        public string question;
        public string answer;
        public string riskLevelIfNo;
        public int actualRiskLevel;
    }
    [Serializable]
    public class Question
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string riskLevelIfNo { get; set; }
        public int actualRiskLevel { get; set; }
    }
