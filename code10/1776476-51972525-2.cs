    if (conversation.Modalities.TryGetValue(ModalityTypes.AudioVideo, out var modality))
    {
        if (modality is AVModality avModality && avModality.CanInvoke(ModalityAction.Disconnect))
        {
            avModality.BeginDisconnect(ModalityDisconnectReason.Busy, ar =>
            {
                try
                {
                    avModality.EndDisconnect(ar);
                }
                catch (Exception ex)
                {
                    // log ex message
                }
            }, null);
        }
        else
        {
            // fallback
            conversation.End();
        }
    }
