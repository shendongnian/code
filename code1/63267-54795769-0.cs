    private static string BuildClause<T>(IList<T> clause)
    {
        if (clause.Count > 0)
        {
            switch (clause[0])
            {
                case int x: // do something with x, which is an int here...
                case decimal x: // do something with x, which is a decimal here...
                case string x: // do something with x, which is a string here...
                ...
                default: throw new ApplicationException("Invalid type");
            }
        }
    }
