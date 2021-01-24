    public class TestClass
    {
        public delegate Task TestHandlerAsync(object sender);
        public event TestHandlerAsync TestAsync;
    
        private async Task OnTestAsync()
        {
            var testAsync = this.TestAsync;
    
            if (testAsync == null)
            {
                return;
            }
    
            await Task.WhenAll(
                from TestHandlerAsync d in testAsync.GetInvocationList()
                select d.Invoke(this));
        }
    
        public async Task TestTestAsync()
        {
            try
            {
                await OnTestAsync();
            }
            catch (Exception ex)
            {
                Program.ConsoleWriteLine($"{nameof(TestTestAsync)}: {ex.Message}", ConsoleColor.Green);
            }
        }
    }
