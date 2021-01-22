    Logger logger = new Logger();
    Stopwatch stopWatch = new Stopwatch();
    logger.StartTimerLogInformation(stopWatch, "SomeObject.SomeMethod");
    SomeResponse response = someObject.SomeMethod(someParam);
    logger.StopTimerLogInformation(stopWatch, "SomeObject.SomeMethod");
