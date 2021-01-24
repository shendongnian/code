    Task<string> GetStringedResult<T>(Task<T> initialTask)
    {
        return initialTask.ContinueWith(t => {
            return t.Exception?.InnerException.Message ?? t.Result.ToString();
        });
    }
    async Task<string> RunAll()
    {
        string m1result, m2result, m3result, m4result;
        var m1task = GetStringedResult(M1());
        var m2task = GetStringedResult(M2());
        var m3task = GetStringedResult(M3());
        var m4task = GetStringedResult(M4());
        m1result = await m1task;
        m2result = await m2task;
        m3result = await m3task;
        m4result = await m4task;
        return $"M1: {m1result}, M2: {m2result}, M3: {m3result}, M4: {m4result}";
    }
