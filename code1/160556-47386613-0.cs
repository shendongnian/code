		int x=550;
		string s=" ";
		string y=" ";
		
		while (x>0)
		{
			
			s += x%2;
			x=x/2;
		}
	
		
		Console.WriteLine(Reverse(s));
	}
	
	public static string Reverse( string s )
	{
		char[] charArray = s.ToCharArray();
		Array.Reverse( charArray );
		return new string( charArray );
	}
