		[STAThread]
		static void Main(string[] args)
		{
			byte[] pattern = new byte[] {12,3,5,76,8,0,6,125};
			byte[] toBeSearched = new byte[] {23,36,43,76,125,56,34,234,12,3,5,76,8,0,6,125,234,56,211,122,22,4,7,89,76,64,12,3,5,76,8,0,6,125};
			string needle, haystack;
		
			unsafe 
			{
				fixed(byte * p = pattern) {
					needle = new string((SByte *) p, 0, pattern.Length);
				} // fixed
				
				fixed (byte * p2 = toBeSearched) 
				{
					haystack = new string((SByte *) p2, 0, toBeSearched.Length);
				} // fixed
				
				int i = haystack.IndexOf(needle, 0);
				System.Console.Out.WriteLine(i);
			}
		}
