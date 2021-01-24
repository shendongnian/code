 lang-cs
public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
{
   if(turnContext.IsReplayingTurnBecauseOfException())
   {
       ... send sorry msg and restart dialogs from wherever you want ...
   }
}
Where the `IsReplayingTurnBecauseOfException` (name up for debate) is an extension method for `ITurnContext` that would be provided along with this new piece of middleware to abstract code from reading `TurnState` details directly. Something like:
 lang-cs
public static bool IsReplayingTurnBecauseOfException(this ITurnContext turnContext) =>
    turnContext.TurnState.ContainsKey("MySuperAwesomeExceptionHandlingMiddleware.IsReplayingBecauseOfException");
