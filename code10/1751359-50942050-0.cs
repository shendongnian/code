    public bool SetPiece(string strGlobal, string strNodes, string strCode, int intPiece, string strNewVal)
    {
        Initialize();
        if (strGlobal == "" | strNodes == "" | strCode == "")
            SetPiece = false;
        SetPiece = mobjUtility.SetPiece(strGlobal, strNodes, strCode, intPiece, strNewVal);
    }
