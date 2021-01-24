    public bool SetPiece(string strGlobal, string strNodes, string strCode, int intPiece, string strNewVal)
    {
    	bool tempSetPiece = false;
    	Initialize();
    	if (string.IsNullOrEmpty(strGlobal) || string.IsNullOrEmpty(strNodes) || string.IsNullOrEmpty(strCode))
    		tempSetPiece = false; //no effect
    
    	return mobjUtility.SetPiece(strGlobal, strNodes, strCode, intPiece, strNewVal);
    }
