    switch(e.EventType)
    {
      case SerialData.Chars:
      {
        // means you receives something
        break;
      }
      case SerialData.Eof:
      {
        // means receiving ended
        break;
      }
    }
