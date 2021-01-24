    class MyClass
    {
        public async Task<int> GetValueAsync(int i)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            return i;
        }
    }
