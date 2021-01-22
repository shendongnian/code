		//===================================================================================
	// NEXT VALUE IN ENUM 
	// ex: E_CamModes eNew =  kGlobalsVars.eGetNextValue< E_CamModes >( geCmMode );
	public static T eGetNextValue< T >( T eIn ){
		T[] aiAllValues = ( T[] ) Enum.GetValues( typeof( T ));
		int iVal = System.Array.IndexOf( aiAllValues, eIn );
		return aiAllValues[ ( iVal + 1 ) % aiAllValues.Length ];
	}
