    public class ControllerActionFilter : IAsyncActionFilter, IOrderedFilter
    {
    	// Controller-filter methods run farthest from the action by default.
    	/// <inheritdoc />
    	public int Order { get; set; } = int.MinValue;
    
    	// ...
    }
