    void _IUccSessionManagerEvents.OnIncomingSession(IUccEndpoint eventSource, UccIncomingSessionEvent eventData)
    {
      // Handle incoming IM session
      if (eventData.Session.Type == UCC_SESSION_TYPE.UCCST_INSTANT_MESSAGING)
      {
        // ...
      }
      else if (eventData.Session.Type == UCC_SESSION_TYPE.UCCST_AUDIO_VIDEO)
      {
        // ... check here first if it's audio only or av...
      }
      // ...
    }
