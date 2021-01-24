    public void SubscribeColorChanged(EventHandler handler, params Color[] colors)
    {
      foreach (Color c in colors)
      {
        colorChangedHandlers[c] += handler;
      }
    }
