	/// <summary>
	/// Determines whether two dates fall in the same week span.
	/// </summary>
	/// <param name="left">The left DateTime to compare.</param>
	/// <param name="right">The right DateTime to compare.</param>
	/// <returns>
	/// </returns>
	public bool IsSameWeek(DateTime left, DateTime right) {
		return AreDatePartsEqual(GetStartOfWeek(left), GetStartOfWeek(right));
	}
	/// <summary>
	/// Gets the start of week.
	/// </summary>
	/// <param name="date">The date.</param>
	/// <returns></returns>
	public DateTime GetStartOfWeek(DateTime date) {
		return date.AddDays(-1 * (int)date.DayOfWeek);
	}
	/// <summary>
	/// Compares two DateTimes using only the Date Part for equality
	/// </summary>
	/// <param name="left">The left DateTime to compare.</param>
	/// <param name="right">The right DateTime to compare.</param>
	/// <returns></returns>
	public bool AreDatePartsEqual(DateTime left, DateTime right) {
		return
			left.Day == right.Day &&
			left.Month == right.Month &&
			left.Year == right.Year;
	}
