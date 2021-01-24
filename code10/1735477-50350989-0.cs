	private string[] MemberName = new string[10];
	public string get_MemberName(object Index)
	{
		return MemberName[(int)Index];
	}
	public void set_MemberName(object Index, string Value)
	{
		MemberName[(int)Index] = Value;
	}
