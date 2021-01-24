    public IActionResult Action(int num)
    {
        //operations-1
        Task.Run(() => DoWork(num)); // async call not awaited
        //operations-2
        int a = num + 123;
        return Ok(a);
    }
    public async Task<bool> DoWork(int num)
    {
        await Task.Delay(10000);
        var i = 9; // breakpoint will hit after 10s
        return true;
    }
