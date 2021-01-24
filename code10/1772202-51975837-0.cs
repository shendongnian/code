    foreach (var column in EasyQueryCachedObject.Columns)
    {
    	if (column.Expr.GetType() == typeof(DbEntityAttrExpr))
    	{
    		((DbEntityAttrExpr)column.Expr).Attribute.Quote = true;
    	}
    }
