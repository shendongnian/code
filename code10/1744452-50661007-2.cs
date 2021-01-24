    public class TestClass
    {
        public delegate Task TestHandlerAsync(object sender);
        public event TestHandlerAsync TestAsync;
    
        private async Task<Exception[]> OnTestAsync()
        {
            var testAsync = this.TestAsync;
    
            if (testAsync == null)
            {
                return new Exception[0];
            }
    
            return await Task.WhenAll(
                from TestHandlerAsync d in testAsync.GetInvocationList()
                select ExecuteAsync(d));
            
            async Task<Exception> ExecuteAsync(TestHandlerAsync d)
            {
                try
                {
                    await d(this);
                    return null;
                }
                catch (Exception ex)
                {
                    return ex;
                }
            }
        }
    
        public async Task TestTestAsync()
        {
            try
            {
                var exceptions = await OnTestAsync();
                
                foreach (var exception in exceptions)
                {
                    if (exception != null)
                    {
                        Program.ConsoleWriteLine($"{nameof(TestTestAsync)}: {exception.Message}", ConsoleColor.Green);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ConsoleWriteLine($"{nameof(TestTestAsync)}: {ex.Message}", ConsoleColor.Green);
            }
        }
    }
