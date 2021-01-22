    public int Compare(Object stringA, Object stringB)
    {
        string[] valueA = stringA.ToString().Split('/');
        string[] valueB = stringB.ToString().Split('/');
        if (valueA.Length != 2 || valueB.Length != 2)
        {
            stringA.ToString().CompareTo(stringB.ToString()));
        }
        // Note: do error checking and consider i18n issues too :)
        if (valueA[0] == valueB[0]) 
        {
            return int.Parse(valueA[1]).CompareTo(int.Parse(valueB[1]));
        }
        else
        {
            return int.Parse(valueA[0]).CompareTo(int.Parse(valueB[0]));
        }
    }
