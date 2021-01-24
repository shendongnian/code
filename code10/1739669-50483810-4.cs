	public enum School
	{
	    DVB=1,
	    AVD=2,
	    ASB=3
	}
	readonly IDictionary SchoolMap = new Dictionary<char,School>() {
		{'D', School.DVB},
		{'A', School.AVD},
		{'B', School.ASB}
	};
	void Main()
	{
		Console.WriteLine(SchoolMap['A']);
	}
