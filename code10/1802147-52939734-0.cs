    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly TinyBooksDbContext context = new TinyBooksDbContext();
         
        ......
		protected virtual void Dispose(bool disposing)
		{
		    if (!_disposed)
		    {
		        if (disposing)
		        {
		            _context.Dispose();
		        }
		    }
		    _disposed = true;
		}
		public void Dispose()
		{
		    Dispose(true);
		    GC.SuppressFinalize(this);
		}
    }
