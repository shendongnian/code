      var command = ReactiveCommand.CreateFromTask(async () =>
                { // define the work
                    Console.WriteLine("Executing at " + DateTime.Now);
                    await Task.Delay(1000);
                    return "test";
                });
    
                command.Subscribe(res => {
                    // do something with the result: assign to property
                });
    
                var d = Observable.Interval(TimeSpan.FromMilliseconds(500), RxApp.TaskpoolScheduler) // you can specify scheduler if you want
                    .Do(_ => Console.WriteLine("Invoking at " + DateTime.Now))
                    .Select(x => Unit.Default) // command argument type is Unit
                    .InvokeCommand(command); // this checks command.CanExecute which is false while it is executing
