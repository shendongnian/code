    public class RecurringJobFacade : IRecurringJobFacade
    {
    	public void AddOrUpdate(Expression<Action> methodCall, Func<string> cronExpression)
    	{
    		RecurringJob.AddOrUpdate(methodCall, cronExpression);
    	}
    }
