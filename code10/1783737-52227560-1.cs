    Mapper.Initialize(cfg =>
    {
    	GenericEnumerableExpressionBinder.InsertTo(cfg.Advanced.QueryableBinders);
    	// ...
    });
