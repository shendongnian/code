    var get1Task = AService.Call1Async();
    var get2Task = BService.Call2Async();
    var get3Task = CService.Call3Async();
    
    await Task.WhenAll(get1Task, get2Task, get3Task);
    var r1 = get1Task.Result;
    var r2 = get2Task.Result;
    var r3 = get3Task.Result;
    //more logic
