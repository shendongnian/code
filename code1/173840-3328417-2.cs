    public bool IsSQLQueryValid(string sql, out List<string> errors)
    {
        errors = new List<string>();
        TSql140Parser parser = new TSql140Parser(false);
        TSqlFragment fragment;
        IList<ParseError> parseErrors;
        using (TextReader reader = new StringReader(sql))
        {
            fragment = parser.Parse(reader, out parseErrors);
            if (parseErrors != null && parseErrors.Count > 0)
            {
                errors = parseErrors.Select(e => e.Message).ToList();
                return false;
            }
        }
        return true;
    }
