    InstantMessageModality instantMessageModality = conversation.Modalities[ModalityTypes.InstantMessage] as InstantMessageModality;
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
        });
