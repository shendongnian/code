    if (conversation.Modalities.TryGetValue(ModalityTypes.InstantMessage, out var modality))
    {
        if (modality is InstantMessageModality instantMessageModality && instantMessageModality.CanInvoke(ModalityAction.SendInstantMessage))
        {
            instantMessageModality.BeginSendMessage("No.", ar =>
            {
                try
                {
                    instantMessageModality.EndSendMessage(ar);
                }
                catch (Exception ex)
                {
                    // log ex message
                }
            }, null);
        }
    }
