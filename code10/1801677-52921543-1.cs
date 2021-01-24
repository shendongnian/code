	public class Answer
	{
		public string Title {get;set;}
		public bool IsCorrect {get;set;}
	}
	
	public class Question
	{
		public string QuestionText {get;set;}
		public IList<Answer> Answers {get;set;}
	}
