	void Main()
	{
		((FieldName)Enum.Parse(typeof(FieldName), "Name", true)).ToString().Dump();
		((FieldName)Enum.Parse(typeof(FieldName), "TaskName", true)).ToString().Dump();
		((FieldName)Enum.Parse(typeof(FieldName), "IsActive", true)).ToString().Dump();
		((FieldName)Enum.Parse(typeof(FieldName), "TaskIsActive", true)).ToString().Dump();
	}
	
	public enum FieldName
	{
		Name,
		TaskName = Name,
		IsActive,
		TaskIsActive = IsActive
	}
