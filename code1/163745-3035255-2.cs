    public void InitiateGenerateImages(List<Coordinate> coordinates)   
    {
      var dispatcher = Dispatcher.CurrentDispatcher;
      var generatorThreadStarter = new ThreadStart(() =>
         GenerateImages(coordinates, dispatcher));
      ...
