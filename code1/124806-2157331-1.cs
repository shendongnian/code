        public void Dispose()
        {
            this.Close();
        }
        public override void Close()
        {
            if( !IsClosed )
                CloseInternal(true);
        }
        private void CloseInternal(bool closeReader)
        {
            try
            {
                // Do some stuff to close the reader itself
            }
            catch(Exception ex)
            {
                this.Connection.Abort();
                throw;
            }
            if( this.Connection != null && CommandBehavior.CloseConnection == true )
            {
                this.Connection.Close();
            }
        }
