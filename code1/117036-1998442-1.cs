    private static void OnSocketConnected1 (IAsyncResult asynchronousResult)
    {
      try
      {
        m_client.EndConnect(asynchronousResult);
      }
      catch { }
    }
