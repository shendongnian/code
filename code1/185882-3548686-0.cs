	class YourStringComparer : System.Collections.Generic.IEqualityComparer<string[]>
	{
		public bool Equals(string[] x, string[] y)
		{
			throw new NotImplementedException(); // not used here
		}
		public int GetHashCode(string[] obj)
		{
			return obj.First().GetHashCode();
		}
	}
	string[] arr = new[] { "s_0001", "s_0002", "s_0003", "sa_0004", "sa_0005", "sab_0006", "sab_0007" };
	var r = arr.Select(s => s.Split('_')).Distinct(new YourStringComparer());
	// "s_0001", "sa_0004", "sab_0006"
