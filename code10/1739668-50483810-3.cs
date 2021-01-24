	void Main()
	{
		Console.WriteLine((School)Enum.Parse(typeof(ConvertSchool),"A"));
	}
	public enum School
	{
	    DVB=1,
	    AVD=2,
	    ASB=3
	}
	public enum ConvertSchool
	{
		D =1,
		A =2,
		B =3
	}
