    private void ConversationManager_ConversationAdded(object sender, ConversationManagerEventArgs e)
    {
        if (e.Conversation.Modalities.TryGetValue(ModalityTypes.AudioVideo, out var avModality))
        {
            avModality.ModalityStateChanged += AvModalityOnStateChanged;
        }
    }
    
    private void AvModalityOnStateChanged(object sender, ModalityStateChangedEventArgs e)
    {
        if (e.NewState == ModalityState.Notified)
        {
            bool conversationIsIncoming = true;
        }
    }
