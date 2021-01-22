    Thread loopTime = new Thread(someFunction);
    loopTime.Start(someTime);
    
    public void someFunction(object someTime) {
        for (int i = 0; i < 20; i++)
        {
            // Note the cast here... I assumed it's a DateTime
            ChangeTimeFunction((DateTime) someTime);
            Thread.Sleep(200);
        }
    }
