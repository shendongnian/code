    var actionRunner = new ActionRunner
    {
        AttemptAction = () =>
        {
            Console.WriteLine("Going to throw...");
            throw new Exception("Just throwing");
        },
        ExceptionAction = () => Console.WriteLine("ExceptionAction"),
        SuccessfulAction = () => Console.WriteLine("SuccessfulAction"),
    };
    actionRunner.RunAction();
    
    actionRunner.AttemptAction = () => Console.WriteLine("Running some other code...");
    actionRunner.RunAction();
