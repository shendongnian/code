    public class FooActionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MinValue;
    
    	//	...
    }
