	public class ReadOnly<T> // or WriteOnce<T> or whatever name floats your boat
	{
	    private readonly TaskCompletionSource<T> _tcs = new TaskCompletionSource<T>();
		
		public Task<T> ValueAsync => _tcs.Task;
		public T Value => _tcs.Task.Result;
	
	    public void SetInitialValue(T value)
	    {
	        try
	        {	        
	        	_tcs.SetResult(value);
	        }
	        catch (InvalidOperationException)
	        {
				throw new InvalidOperationException("The value has already been set.");
	        }
	    }
    	public static implicit operator T(ReadOnly<T> readOnly) => readOnly.Value;
	    public static implicit operator Task<T>(ReadOnly<T> readOnly) => readOnly.ValueAsync;
    }
