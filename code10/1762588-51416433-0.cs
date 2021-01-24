    TimeSpan period = TimeSpan.FromSeconds(5);
    Float previousCounter;
    
    ThreadPoolTimer PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
        {
        //
        if (counter == previousCounter)
        {
            Console.WriteLine("Nothing happened for 5 seconds");
        
        
            Dispatcher.RunAsync(CoreDispatcherPriority.High, () => {
            //Affect gui?
            });
        }
        previousCounter = counter;
    }, period);
