	public static bool Contains ( this String str , String[] testValues )
	{
		foreach ( var value in testValues )
		{
			if ( str.Contains( value ) )
				return true;
		}
		return false;
	}
