    SetGameAreaDelegate handler;
    class MyGameClass
    {
        MyGameClass()
        {
            // Instantiate the handler (since this is a member method not-static)
            // you'll need to assign it in the constructor because 'this'
            // must be valid which is not during initialization 
            handler = new SetGameAreaDelegate(myGameAreaWithCallback);
            handler = MyGameAreaWithCallback; // short for same as above
        }
        void MyGameAreaWithCallback(Game1.gameAreas newArea)
        {
        //...
        }
    }
