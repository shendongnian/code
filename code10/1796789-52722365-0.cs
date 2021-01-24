    public interface IDbConnection
    {
        Task<ObservableCollection<Einkauf>> GetEinkauf();
    }
    
    public async Task<ObservableCollection<Einkauf>> GetEinkauf()
    {
      ...
    }
