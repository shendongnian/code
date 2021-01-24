    public string Encrypt(ref string PassStr)
    {
        short Pos, StrLen, i, iValue;
        string RetValue;
        iValue = 100;
        StrLen = Strings.Len(PassStr);
        RetValue = "";
    
        for (i = 1; i <= StrLen; i++)
        {
            Pos = Strings.Asc(Strings.Mid(PassStr, i, 1)) + (iValue + i);
            RetValue = RetValue + Strings.Chr(Pos);
        }
        Encrypt = RetValue;
    }
