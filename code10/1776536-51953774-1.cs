    public async Task<DataViewModel> GetDataInParallel()
    {
        var result1Task = _databaseRepo.QuerySomething();
        var result2Task = _databaseRepo.QuerySomethingElse();
        await Task.WhenAll(result1Task, result2Task);
    
        return new DataViewModel(result1Task.Result, result2Task.Result);
    }
