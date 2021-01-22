	//===================================================================================
	// NEXT VALUE IN ENUM 
	// ex: E_CamModes eNew =  kGlobalsVars.eGetNextValue< E_CamModes >( geCmMode );
	public static T eGetNextValue< T >( T eIn ){
		T[] aiAllValues = ( T[] ) Enum.GetValues( typeof( T ));
		int iVal = System.Array.IndexOf( aiAllValues, eIn );
		if( iVal < 0 ){
			Debug.Log( CH_Mas + SZ_ERROR + eIn.ToString() ) ;
		}
		if( iVal == aiAllValues.Length - 1){
			Debug.Log( CH_Mns + SZ_ERROR + eIn.ToString() ) ;
		}
		return aiAllValues[ ( iVal + 1 ) % aiAllValues.Length ];
	}
	
