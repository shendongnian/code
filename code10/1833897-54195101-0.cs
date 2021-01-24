    var collection = new CustomCollection();
    var mokedAmplifier = new Mock<IDataLoader>(MockBehavior.Loose);
    mokedAmplifier.SetupAllProperties();
    MainController.Loader = mokedAmplifier.Object;
    if(MainController.Loader.ItemsToBeProcessed == null)
        MainController.Loader.ItemsToBeProcessed = new CustomCollection();
    //...
