        protected override void Dispose(bool disposing)
        {
            if (_bDisposed)
                return;
            if ( disposing )
            {
                _context.Dispose();
            }
            _bDisposed = true;
            base.Dispose(disposing);
        }
        private bool _bDisposed;
