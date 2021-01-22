	public interface ISampleView
	{
		UiField<bool> IsStaffFullTime { get; set; }
		UiField<string> StaffName { get; set; }
		UiField<string> JobTitle { get; set; }
		UiField<int> StaffAge { get; set; }
		UiField<IList<string>> Certifications { get; set; }
	}
