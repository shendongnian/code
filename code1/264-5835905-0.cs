	public class Grammar
	{
		/// <summary> Gets or sets the term for "just now". </summary>
		public string JustNow { get; set; }
		/// <summary> Gets or sets the term for "X minutes ago". </summary>
		/// <remarks>
		///     This is a <see cref="String.Format"/> pattern, where <c>{0}</c>
		///     is the number of minutes.
		/// </remarks>
		public string MinutesAgo { get; set; }
		public string OneHourAgo { get; set; }
		public string HoursAgo { get; set; }
		public string Yesterday { get; set; }
		public string DaysAgo { get; set; }
		public string LastMonth { get; set; }
		public string MonthsAgo { get; set; }
		public string LastYear { get; set; }
		public string YearsAgo { get; set; }
		/// <summary> Gets or sets the term for "ages ago". </summary>
		public string AgesAgo { get; set; }
		/// <summary>
		///     Gets or sets the threshold beyond which the fuzzy date should be
		///     considered "ages ago".
		/// </summary>
		public TimeSpan AgesAgoThreshold { get; set; }
    
		/// <summary>
		///     Initialises a new <see cref="Grammar"/> instance with the
		///     specified properties.
		/// </summary>
        private void Initialise(string justNow, string minutesAgo,
            string oneHourAgo, string hoursAgo, string yesterday, string daysAgo,
            string lastMonth, string monthsAgo, string lastYear, string yearsAgo,
            string agesAgo, TimeSpan agesAgoThreshold) { ... }
    }
