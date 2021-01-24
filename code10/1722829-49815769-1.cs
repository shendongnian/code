    class AsyncClass
    {
        public string Hello = "ASYNC NOT DONE";
        public AsyncClass()
        {
            
        }
        private async Task<string> ChangeHello()
        {
            await Task.Yield();
            await Task.Delay(2000);
            return "ASYNC DONE";
        }
        public async Task ChangeHello1()
        {
            Hello = await ChangeHello();
        }
    }
