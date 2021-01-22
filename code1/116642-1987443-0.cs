    do
    {
      String c = MLTWatcherTCPIP.Get().ToUpper();
      if (c = "")
        MLTWatcherTCPIP.TerminalPrompt.ScrollBodyTextDown();
      else if (c = "P")
        MLTWatcherTCPIP.TerminalPrompt.ScrollBodyTextUp();
      else if (c = "D")
         break;
      else if (c = "Q")
        return;
      else
      {
        // Handle bad input here.
      }
    } while (keepLooping)
