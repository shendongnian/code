    public static int CompareVersions(string strA, string strB)
    {
        char[] splitTokens = new char[] {'.', ','};
        string[] strAsplit = strA.Split(splitTokens, StringSplitOptions.RemoveEmptyEntries);
        string[] strBsplit = strB.Split(splitTokens, StringSplitOptions.RemoveEmptyEntries);
        int versionA = 0;
        int versionB = 0;
        string vA = string.Empty;
        string vB = string.Empty;
        for (int i = 0; i < 4; i++)
        {
            vA += strAsplit[i];
            vB += strBsplit[i];
            versionA[i] = Convert.ToInt32(strAsplit[i]);
            versionB[i] = Convert.ToInt32(strBsplit[i]);
        }
        versionA = Convert.ToInt32(vA);
        versionB = Convert.ToInt32(vB);
        if(vA > vB)
           return 1;
        else if(vA < vB)
           return -1;
        else
           return 0;  //they are equal
    }
