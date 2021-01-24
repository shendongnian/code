    public void runDDEServer()
    {
      try
      {
        using (DdeServer server = new theDDEServer("dde_server"))
        {
          server.Register();
        }
      }
      catch (Exception ex)
      {
      }
    }
