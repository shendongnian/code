    public class TestEchoBotAccessors
    {
        public TestEchoBotAccessors(ConversationState conversationState)
        {
            ConversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));
        }
    
        public ConversationState ConversationState { get; }
        public IStatePropertyAccessor<DialogState> ConversationDialogState { get; set; }
    }
