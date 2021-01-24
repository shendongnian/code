    class DataClass //: IFieldExposer<DataClass>
    {
    	// ...
    
    	public static IEnumerable<Expression<Func<DataClass, string>>> GetFields()
    	{
    		return new List<Expression<Func<DataClass, string>>>
    		{
    			a => a.PropertyOne,
    			b => b.Child.PropertyThree
    		};
    	}
    }
