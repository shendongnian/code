    private static IEnumerable SplitInnerLoop(IEnumerator iter, TokenType type)
    {
        do
        {
            Token token = iter.Current as Token;
            if ((token != null) && token.TokenType == type)
            {
                break;
            }
            else if ((iter.Current is TokenType) && ((TokenType)iter.Current) == type)
            {
                break;
            }
            else
            {
                yield return iter.Current;
            }
        } while (iter.MoveNext());
    }
    public static IEnumerable<IEnumerable> Split(this  IEnumerable tokens, TokenType type)
    {
        IEnumerator iter = tokens.GetEnumerator();
        while (iter.MoveNext())
        {
            yield return SplitInnerLoop(iter, type);
        }
    }
