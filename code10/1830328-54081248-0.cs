    public class MyActivityLoggingMiddleware : IMiddleware
    {
        public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
        {
            // log incoming activity from turnContext.Activity here
            // Hook the turn context's OnSendActivities
            turnContext.OnSendActivities(HandleSendActivities);
            await next(cancellationToken);
        }
        private async Task<ResourceResponse[]> HandleSendActivities(ITurnContext turnContext, List<Activity> activities, Func<Task<ResourceResponse[]>> next)
        {
            // log activities being sent here
            return await next();
        }
    }
