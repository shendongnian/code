    List<int> iCodes = new List<int>();
    int iCode = 0;
    string[] sNums = IDs.Trim('[').Trim(']').Split(',');
    
    foreach (string sCode in sNums)
    {
        if (int.TryParse(sCode, out iCode))
            iCodes.Add(iCode);
    }
