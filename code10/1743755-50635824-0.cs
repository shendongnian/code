    public static void Main()
	{
		Dictionary<KeyPair, int> betterDict = new Dictionary<KeyPair, int>();
		betterDict.Add(new KeyPair("NAME", 1), 23);
		betterDict.TryGetValue(new KeyPair("NAME", 1), out int val);
		Console.WriteLine(val); //23
	}
	public class KeyPair
	{
		public string Name
		{
			get;
		}
		public int Int
		{
			get;
		}
		public KeyPair(string name, int i)
		{
			Name = name;
			Int = i;
		}
		protected bool Equals(KeyPair other)
		{
			return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase) && Int == other.Int;
		}
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != this.GetType())
				return false;
			return Equals((KeyPair)obj);
		}
		public override int GetHashCode()
		{
			unchecked
			{
				return ((Name != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(Name) : 0) * 397) ^ Int;
			}
		}
		public static bool operator ==(KeyPair left, KeyPair right)
		{
			return Equals(left, right);
		}
		public static bool operator !=(KeyPair left, KeyPair right)
		{
			return !Equals(left, right);
		}
	}
