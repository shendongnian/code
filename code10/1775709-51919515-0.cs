    interface IStore
    {
      void Save(int id, string data);
      Task SaveAsync(int id, string data);
      string Read(int id);
      Task<string> ReadAsync(int id);
    }
