    class MyGameClass
    {
        SetGameAreaDelegate handler;
        MyGameClass()
        {
            // Instantiate the handler (since my callback is a non-static method)
            // You'll need to preform this assignment in the constructor, 'this'
            // is not valid during initialization 
            handler = new SetGameAreaDelegate(myGameAreaWithCallback);
            handler = MyGameAreaWithCallback; // short for above
        }
        void MyGameAreaWithCallback(Game1.gameAreas newArea)
        {
            //...
        }
    }
