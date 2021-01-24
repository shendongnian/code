    public class DbService : IDisposable
    {
        private bool _isDisposed = false;
        private ApplicationDbContext _context;
        private DbContextTransaction _transaction;
        public DbService()
        {
            _context = new ApplicationDbContext();
            _transaction = _context.Database.BeginTransaction();
        }
        public void InsertInvoice(int invoiceId)
        {
            try
            {
                var invoice1 = new OracleDatabaseService.Models.Invoice()
                {
                    InvoiceId = (invoiceId).ToString(),
                    ClientId = "3",
                    ExternalSystemId = "0"
                };
                _context.Invoices.Add(invoice1);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Dispose(false);
                throw;
            }
        }
        public void Commit(bool isFinal)
        {
            if (!_isDisposed)
            {
                _transaction.Commit();
                if (isFinal)
                {
                    Dispose(false);
                }
                else
                {
                    _transaction.Dispose();
                    _transaction = _context.Database.BeginTransaction();
                }
            }
        }
        public void Rollback(bool isFinal)
        {
            if (!_isDisposed)
            {
                if (isFinal)
                {
                    Dispose(false);
                }
                else
                {
                    _transaction.Rollback();
                    _transaction.Dispose();
                    _transaction = _context.Database.BeginTransaction();
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                if (_transaction != null)
                {
                    if (_transaction.UnderlyingTransaction.Connection != null)
                    {
                        _transaction.Rollback();
                    }
                    
                    _transaction.Dispose();
                }
                if (_context != null)
                {
                    _context.Dispose();
                }
                _isDisposed = true;
            }
        }
        ~DbService()
        {
            Dispose(false);
        }
    }
