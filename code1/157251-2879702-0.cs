    // Financial
    int[] stockPrices = new int[4]{ 15, 14, 18, 16 }; // contains four prices
    foreach( int price in stockPrices )
    {
        MakeTransaction(price);// calls a function that makes a transaction at the price: e.g. buy/sell
    }
    // Gaming
    3DModel[] gameModels = new 3DModel[4]{ new Tank(), new Truck(), new Soldier(), new Building()}; // contains 3D models
    foreach( 3DModel model in gameModels )
    {
        model.Draw();// calls a function of each 3DModel that draws the model on the screen
    }
    // Military
    Target[] targets = new Target[4]{ new Tank(), new Helicopter(), new APC(), new Truck()}; // contains targets
    foreach( Target target in targets )
    {
        Attack(target);// calls an attack function which initiates an attack on each target
    }
