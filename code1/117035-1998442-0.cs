    private static void OnSocketConnected1 (IAsyncResult asynchronousResult)
    {
      try
      {
        // ----- Do some meaningful here.
      }
      catch { }
      finally
      {
        m_client.EndConnect(asynchronousResult);
      }
    }
