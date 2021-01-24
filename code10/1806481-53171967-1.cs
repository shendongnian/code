    var cts = new CancellationTokenSource();
    string uri = "fabric:/appName/ActorServiceName";
    var actor = ActorProxy.Create<IMyActorInterface>(new ActorId(id), new Uri(uri));
    Task<int> actorResut = actor.GetCountAsync(cts.Token);
    //here you can manage what you want to do
    //You could get the result like
    var count = await actorResut;
    //you can check if it has completed like this
    if(actorResut.IsCompleted) {}
    
    //you can cancel the task calling cancel on CTS
    cts.Cancel();
