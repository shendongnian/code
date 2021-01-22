		public static void Main(string[] args)
		{
			string s1 = "abc";
			System.String s2 = "xyz";
			Type t1 = s1.GetType();
			Type t2 = s2.GetType();
			
			System.Console.WriteLine( t1.Equals(t2) );
			return ;
		}
