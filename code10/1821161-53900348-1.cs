    [Fact]
    public async Task Test()
        => await new TestScheduler().With(async scheduler =>
        {
            await SomeAsyncMethod().ConfigureAwait(false);
            // *** execution never gets here
            Debugger.Break();
        }).ConfigureAwait(false);
    private async Task SomeAsyncMethod()
    {
        var command = ReactiveCommand.CreateFromTask(async () =>
        {
            await Task.Delay(100).ConfigureAwait(false);
        }).ConfigureAwait(false);
        // *** this hangs
        await command.Execute();
    }
