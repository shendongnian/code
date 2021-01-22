    public T Retry<T>(Func<T> action, int retryCount = 0)
	{
		PolicyResult<T> policyResult = Policy
		 .Handle<Exception>()
		 .Retry(retryCount)
		 .ExecuteAndCapture<T>(action);
		if (policyResult.Outcome == OutcomeType.Failure)
		{
			throw policyResult.FinalException;
		}
		return policyResult.Result;
	}
