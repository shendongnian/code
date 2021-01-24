    public async Task ConcurrencyIssueTest(int iterations)
    {
        var orderResult = await _driver.PlaceOrder();
    
        var taskA = _Api.TaskA(orderResult.OrderId);
        var taskB = _Api.TaskB(orderResult.OrderId);
    
        await Task.WhenAll(taskA, taskB);
    
    
       var taskAResult = await taskA;
    
        taskAResult.ShouldNotBeNull();
        taskAResult.StatusCode.ShouldBe(HttpStatusCode.OK);
    
        var taskBResult = await taskB;
    
        taskBResult.ShouldNotBeNull();
        taskBResult.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
