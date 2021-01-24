    public static Dictionary<string, int[,]> MinNumOfZeros(Dictionary<string, int[,]> iDict)
    {
        var KeyOfMinimum = iDict.Keys.ArgMin(iKey => CountZeros(iDict[iKey]));
        return new Dictionary<string, int[,]> { { KeyOfMinimum, iDict[KeyOfMinimum] } };
    }
