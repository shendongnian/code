    /* Note I am using string instead of double for PlanAmount and PlanLimitAmount because you have 
	 * those values surrounded by double quotes. If you want to use double instead make sure your JSON does not 
	 * have double quotes around the numbers */
	public class MyClass 
	{
		public string Source { get; set; }
		public int CodePlan { get; set; }
		public string PlanSelection { get; set; }
		public string PlanAmount { get; set; }
		public int PlanLimitCount { get; set; }
		public string PlanLimitAmount { get; set; }
		public bool Visible { get; set; }
		public int? Count { get; set; }
		
	}
