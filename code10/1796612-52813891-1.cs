    public async Task<int> FindWorkingPortAsync(int from, int to)
    {
        var wrapper = new TaskCompletionSource<int>();
        var tasks = Enumerable.Range(from, to - from).ToList().Select(port =>
        {
            return new FtpClient(_host, port).ConnectAsync().ContinueWith(t => {
                try
                {
                    if(!wrapper.Task.IsCompleted && !t.IsFaulted && !t.IsCanceled)
                        wrapper.SetResult(port);
                    return t;
                }
                catch
                {
                    return Task.FromResult(-1);
                }
            });
        }).ToList();
        
        return await wrapper.Task;
    }
