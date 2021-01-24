    public class GenericRetryExecutorRequest2<T>
    {
    	public int RetryCount { get; set; } = 3;
    	public TimeSpan Interval { get; set; } = new TimeSpan(0, 0, 0, 5);
    	public IGenericRetryActions2<T> GenericRetryActions { get; set; }
    }
    
    public interface IGenericRetryActions2<out T>
    {
    	IObservable<T> OnExecute();
    	void OnCatch();
    }
	public static IObservable<T> Retry2<T>(this GenericRetryExecutorRequest2<T> request)
	{
		return Observable.Timer(Timespan.Zero, request.Interval)
			.SelectMany(_ => request.GenericRetryActions.OnExecute())
			.Catch((Exception e) => Observable.Return(Unit.Default)
				.Do(_ => request.GenericRetryActions.OnCatch())
				.SelectMany(Observable.Throw<T>(e))
			)
			.Retry(request.RetryCount);
	}
