    private IEnumerable<String> StreamAsSpaceDelimited(this StreamReader reader)
    {
        StringBuilder builder = new StringBuilder();
        int v;
        while((v = reader.Read()) != -1)
        {
            char c = (char) v;
            if(Char.IsWhiteSpace(c))
            {
                if(builder.Length >0)
                {
                    yield return builder.ToString();
                    builder.Clear();
                }
            }
            else
            {
                builder.Append(c);
            }
        }
        yield break;
    }
