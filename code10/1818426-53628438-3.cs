    static Task PerformWithDelay(this IEnumerable<Action> actionsToPerform, TimeSpan delayTime)
    {
        var actionEnumerator = actionsToPerform.GetEnumerator();
        // do nothing if no actions to perform
        if (!actionEnumerator.MoveNext())
            return Task.CompletedTask;
        else
        {    // Current points to the first action
             Task result = actionEnumerator.Current;
             // enumerate over all other actions:
             while (actionEnumerator.MoveNext())
             {
                 // there is a next action. ContinueWith delay and next task
                 result.ContinueWith(Task.Delay(delayTime)
                       .ContinueWith(Task.Run( () => actionEnumerator.Current);
             } 
         }
    }
