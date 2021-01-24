    [Fact(Timeout = 50)]
    public async Task FactTimeout_TimeoutLessThanProcessingTime_ThrowTestTimeoutException()
    {
        // Arrange
        // Act
        Action act = () => Task.Delay(5000);
    
        // Assert
        await act;
    }
