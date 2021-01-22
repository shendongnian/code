    public void Test()
    {
        List<string> completedProcesses = initialEnumerable
            .SelectTry(x => RiskyOperation(x))
            .OnCaughtException(exception => { _logger.Error(exception); return null; })
            .Where(x => x != null) // filter the ones which failed
            .ToList();
    }
