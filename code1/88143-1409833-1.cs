    public void RecordTransfer(long elapsedTicks)
    {
        using (PerformanceCounter averageTransferTimeCounter = new PerformanceCounter(),
            averageTransferTimeBaseCounter = new PerformanceCounter())
        {
            averageTransferTimeCounter.CategoryName = CreditPerformanceCounter.CategoryName;
            averageTransferTimeCounter.CounterName = CreditPerformanceCounter.AverageTransferTimeCounterName;
            averageTransferTimeCounter.ReadOnly = false;
            averageTransferTimeBaseCounter.CategoryName = CreditPerformanceCounter.CategoryName;
            averageTransferTimeBaseCounter.CounterName = CreditPerformanceCounter.AverageTransferTimeBaseCounterName;
            averageTransferTimeBaseCounter.ReadOnly = false;
            averageTransferTimeCounter.IncrementBy(elapsedTicks);
            averageTransferTimeBaseCounter.Increment();
        }
    }
