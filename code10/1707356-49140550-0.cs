	class Sku
	{
		public string Prefix { get; set; }
		public string Group  { get; set; }
		public string Priority { get; set; }
		public string Suffix { get; set; }
		
		public override string ToString()
		{
			return string.Format("{0}{1}{2}{3}", Prefix, Group, Priority, Suffix);
		}
		
		static public implicit operator Sku(string input)
		{
			return new Sku
			{
				Prefix = input.Substring(0,3),
				Group = input.Substring(3,3),
				Priority = input.Substring(6,3),
				Suffix = input.Substring(9)
			};
		}
		
		static public implicit operator string(Sku input)
		{
			return input.ToString();
		}
	}
