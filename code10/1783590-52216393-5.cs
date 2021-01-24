    private Task<bool> GetStudentResults(CancellationToken token)
    {
        for(int i = 0; i < 10000; i++)
        {
            if (token.IsCancellationRequested)
                return Task.FromResult(false);
            Console.WriteLine(i);
        }
        return Task.FromResult(true);
    }
