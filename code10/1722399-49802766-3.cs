    [Table("StudentSurveys")]
    public class Survey
    {
    	[Column("StudentSurveyId")]
    	public int SurveyId { get; set; }
    	public string Name { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
    	[Column("StudentSurveyId")]
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
    }
