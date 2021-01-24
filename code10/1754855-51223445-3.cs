    public sealed class Class1 {
        public IAsyncOperation<string> GetExample() {
            return AsyncInfo.Run(token => getExampleCore());
        }
        private Task<string> getExampleCore() {
            return Task.FromResult("It's working");
        }
    }
