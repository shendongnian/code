	public static List<TDacObject> Select<TFieldObject>(this PXGraph graph, object fieldParamValue)
		where TFieldObject : class,IBqlField
		where TDacObject : class,IBqlTable
	{
           // 'graph' will be used to provide the required context for query execution
           // 'TDacObject' is a generic DAC type used in the query
           // 'TFieldObject' is a generic DAC type used in the query
           // 'fieldParamValue' is a generic value you can use in your query
	}
