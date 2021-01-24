    public async Task FactTimeout_TimeoutLessThanProcessingTime_ThrowTestTimeoutException()
    {
        Action act = () => Task.Delay(5000);
    
        let timeoutTask = Task.Delay(50);
        let res = await Task.WhenAny(timeoutTask, act);
    
        Assert.IsSame(timeoutTask, res);
    }
