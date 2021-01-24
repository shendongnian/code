    /// <summary>
    ///     Provides helper extensions to Serilog logging.
    /// </summary>
    public static class SerilogExtensions
    {
    	private const           String        SuppressLoggingProperty = "SuppressLogging";
    	private static readonly HashSet<Guid> ActiveSuppressions      = new HashSet<Guid>();
    
    	/// <summary>
    	///     Get disposable token to supress logging for context.
    	/// </summary>
    	/// <remarks>
    	///     Pushes "SuppressLogging" property with unique value to SerilogContext.
    	///     When disposed, disposes Serilog property push token and invalidates stored value so new log messages are no longer
    	///     supressed.
    	/// </remarks>
    	public static IDisposable SuppressLogging()
    	{
    		return new SuppressLoggingDisposableToken();
    	}
    
    	/// <summary>
    	///     Determines whether the given log event suppressed.
    	/// </summary>
    	/// <remarks>
    	///     Also removes "SuppressLogging" property if present.
    	/// </remarks>
    	public static Boolean IsSuppressed(this LogEvent logEvent)
    	{
    		Boolean containsProperty = logEvent.Properties.TryGetValue(SuppressLoggingProperty, out var val);
    		if (!containsProperty)
    			return false;
    
    		logEvent.RemovePropertyIfPresent(SuppressLoggingProperty); //No need for that in logs
    
    		if (val is ScalarValue scalar && scalar.Value is Guid id)
    			return ActiveSuppressions.Contains(id);
    
    		return false;
    	}
    
    	/// <summary>
    	///     Disposable wrapper around logging supression property push/pop and value generation/invalidation.
    	/// </summary>
    	private class SuppressLoggingDisposableToken : IDisposable
    	{
    		private readonly IDisposable _pushPropertyDisposable;
    		private readonly Guid        _guid;
    
    		public SuppressLoggingDisposableToken()
    		{
    			_guid                   = Guid.NewGuid();
    			_pushPropertyDisposable = LogContext.PushProperty(SuppressLoggingProperty, _guid);
    
    			ActiveSuppressions.Add(_guid);
    		}
    
    		public void Dispose()
    		{
    			ActiveSuppressions.Remove(_guid);
    			_pushPropertyDisposable.Dispose();
    		}
    	}
    }
