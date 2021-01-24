    [Fact(Timeout = 50)]
    public async Task FactTimeout_TimeoutLessThanProcessingTime_ThrowTestTimeoutException()
    {
        Action act = () => Task.Delay(5000);
        // Trigger the timeout by attempting something that will take too long
        await act;
    }
