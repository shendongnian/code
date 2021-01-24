    public class PollQuestion
	{
		public string QuestionText { get; set; }
	}
	public class Poll
	{
		public string Question { get; set; }
		public List<PollQuestion> PollQuestions { get; set; }
	}
