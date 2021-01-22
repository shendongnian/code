    private void HandleEvent(string eventName, Delegate handler)
    {
      try
      {
        BindingFlags bindingFlags = BindingFlags.Instance | 
                                    BindingFlags.Public | BindingFlags.NonPublic;
        EventInfo mediaItemFellback = m_PlayerType.GetEvent(eventName, bindingFlags);
        Delegate correctHandler = Delegate.CreateDelegate(
            mediaItemFellback.EventHandlerType, handler.Target, handler.Method);
        mediaItemFellback.AddEventHandler(m_Player, correctHandler);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
    }
