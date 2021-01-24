    public class NotNiceDataBase : ILoader
    {
        public Task<Data> LoadAsync(int id)
        {
            //this database's driver does not have aysnc methods, because it's old or done poorly.    
            var result = NotNiceDataBaseDriver.LoadData(id);
            return Task.FromResult(result);
         }
    }
