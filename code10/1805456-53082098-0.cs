    public override Expression VisitTable(TableExpression tableExpression)
    {
    	// base will append schema, table and alias
    	var result = base.VisitTable(tableExpression);
    	Sql.Append(" WITH (NOLOCK)");
    	return result;
    }
