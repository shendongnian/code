    public bool SetPiece(string strGlobal, string strNodes, string strCode, int intPiece, string strNewVal)
    {
          Initialize();
          if (strGlobal == "" || strNodes == "" ||strCode == "")
             return false;       
          return mobjUtility.SetPiece(strGlobal, strNodes, strCode, intPiece, strNewVal);
    }
