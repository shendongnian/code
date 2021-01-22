    private void Dispose(bool disposing)
    {
        // ...
        if (disposing && (this._innerConnection != null))
        {
            this._disposing = true;
            this.Rollback(); // there you go
        }
    }
