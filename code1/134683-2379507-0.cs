    public static DataContext New
    {
      get
      {
        var cs = IsConnected ? CentralConnectionString : LocalConnectionString;
        return new DataContext(cs);
      }
    }
