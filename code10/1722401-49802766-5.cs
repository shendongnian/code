    public class StudentSurvey
    {
    	public int StudentSurveyId { get; set; }
    	public string Name { get; set; }
    }
    public class User
    {
    	public int SurveyUserId { get; set; }
    	public int StudentSurveyId { get; set; }
    	public StudentSurvey StudentSurvey { get; set; }
    }
