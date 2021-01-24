    private static async Task main()
    {
        B.CheckWebElements("the element name");
        //NOW WE WANT TO WAIT UNTIL CLASS B IS DONE...
        while (!canContinue) await Dispatcher.Yield();
    }
    
