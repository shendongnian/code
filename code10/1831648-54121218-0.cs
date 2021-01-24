CSharp
public class Startup
{
     public void ConfigureServices(IServiceCollection services)
     {
        // Only need a single storage instance unless you really are storing your conversation state and user state in two completely DB instances
        var storage = new CosmosDbStorage(new CosmosDbStorageOptions
        {
            // … set options here …
        });
        var conversationState = new ConversationState(storage);
        var userState = new UserState(storage);
        // Add the states as singletons
        services.AddSingleton(conversationState);
        services.AddSingleton(userState);
        // Create state properties accessors and register them as singletons
        services.AddSingleton(conversationState.CreateProperty<YourBotsConversationState>());
        services.AddSingleton(conversationState.CreateProperty<YourBotsUserState>());
        services.AddBot<SeguritoBot>(options =>
        {
        });
     }
}
Now, in your bot, if you want to access those properties, you take them as dependencies via the constructor:
CSharp
public class SeguritoBot : IBot
{
    private readonly ConversationState _conversationState;
    private readonly UserState _userState;
    private readonly IStatePropertyAccessor<YourBotConversationState> _conversationStatePropertyAccessor;
    private readonly IStatePropertyAccessor<YourBotUserState> _userStatePropertyAccessor;
    public SeguritoBot(
        ConversationState conversationState, 
        UserState userState,
        IStatePropertyAccessor<YourBotConversationState> conversationStatePropertyAccessor,
        IStatePropertyAccessor<YourBotUserState> userStatePropertyAccesssor)
    {
        _conversationState = conversationState;
        _userState = userState;
        _conversationStatePropertyAcessor = conversationStatePropertyAcessor;
        _userStatePropertyAcessor = userStatePropertyAcessor;
    }
    public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
    {
        var currentConversationState = await _conversationStatePropertyAccessor.GetAsync(
            turnContext,
            () => new YourBotConversationState(), 
            cancellationToken);
        // Access properties for this conversation
        // currentConversationState.SomeProperty
        // Update your conversation state property
        await _conversationStatePropertyAccessor.SetAsync(turnContext, currentConversationState, cancellationToken);
        // Commit any/all changes to conversation state properties
        await _conversationState.SaveChangesAsync(turnContext, cancellationToken);
    }
}
Obviously you can do the same with the user state property and you can support multiple properties per state scope with more calls to `CreateProperty` and injecting those `IStatePropertyAccessor<T>` as well, etc.
