    private bool IsInt(string sVal)
    {
        foreach (char c in sVal)
        {
             int iN = (int)c;
             if ((iN > 57) || (iN < 48))
                return false;
        }
        return true;
    }
 
