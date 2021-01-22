    public void InitiateGenerateImages(List<Coordinate> coordinates)   
    {
      var myDispatcher = Dispatcher.CurrentDispatcher;
      var generatorThreadStarter = new ThreadStart(() =>
         GenerateImages(coordinates, dispatcher));
      ...
