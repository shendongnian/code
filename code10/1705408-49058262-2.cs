    public void UnsubscribeColorChanged(EventHandler handler, params Color[] desiredColors)
    {
      foreach (Color c in desiredColors)
      {
        foreach (KeyValuePair<Color, EventHandler> kvp in colorChangedHandlers)
        {
          if (kvp.Key == c)
            kvp.Value -= handler; 
        }
      }
    }
