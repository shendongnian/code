    public interface IUnitOfWork : IDisposable
    {
      void Commit();
      void RollBack();
    }
