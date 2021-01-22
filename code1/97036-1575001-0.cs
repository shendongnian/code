    private Dictionary<string, ParameterExpression> variables
        = new Dictionary<string, ParameterExpression>();
    public Expression Visit(ITree tree)
    {
        switch(tree.Type)
        {
            case MyParser.NUMBER_LITERAL:
                {
                    float value;
                    var literal = tree.GetChild(0).Text;
                    if (!Single.TryParse(literal, out value))
                        throw new MyParserException("Invalid number literal");
                    return Expression.Constant(value);
                }
            case MyParser.IDENTIFIER:
                {
                    var ident = tree.GetChild(0).Text;
                    if (!this.variables.ContainsKey(ident))
                    {
                        this.variables.Add(ident,
                           Expression.Parameter(typeof(float), ident));
                    }
                    return this.variables[ident];
                }
            case MyParser.ADD_EXPR:
                return Expression.Add(Visit(tree.GetChild(0)), Visit(tree.GetChild(1)));
            // ... more here
        }
    }
