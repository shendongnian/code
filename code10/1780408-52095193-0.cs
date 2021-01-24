    class NotNiceDataBase : ILoader 
    {
        public Task<Data> LoadAsync(int id)
        {
            var data = NotNiceDataBaseDriver.LoadData(id);
            return Task.From(data);
        }
    }
