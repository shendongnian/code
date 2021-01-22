    public static IEnumerable<IEnumerable> Split(this  IEnumerable tokens, TokenType type)
    {
        ArrayList currentT = new ArrayList();
        foreach (object list in tokens)
        {
            Token token = list as Token;
            if ((token != null) && token.TokenType == type)
            {
                yield return currentT;
                currentT.Clear();
                //currentT = new ArrayList(); <-- Use this instead of 'currentT.Clear();' if you want the returned lists to be a different instance
            }
            else if ((list is TokenType) && ((TokenType)list) == type)
            {
                yield return currentT;
                currentT.Clear();
                //currentT = new ArrayList(); <-- Use this instead of 'currentT.Clear();' if you want the returned lists to be a different instance
            }
            else
            {
                currentT.Add(list);
            }
        }
    }
