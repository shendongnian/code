    public class SomeOtherClass : IDbConnection
    {
        public Task<ObservableCollection<Einkauf>> GetEinkaufAsync()
        {
            return Task.FromResult(new ObservableCollection<Einkauf>());
        }
    }
