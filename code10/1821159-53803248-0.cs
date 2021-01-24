     [Fact]
        public async Task Test()
            => await new TestScheduler().With(async scheduler =>
            {
                // this hangs
                await SomeAsyncMethod().ConfigureAwait(false);
    
                // ***** execution will never get to here
                Debugger.Break();
            }
