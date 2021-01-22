    private void Dispose(bool disposing)
    {
        Bid.PoolerTrace("<sc.SqlInteralTransaction.Dispose|RES|CPOOL> %d#, Disposing\n", this.ObjectID);
        if (disposing && (this._innerConnection != null))
        {
            this._disposing = true;
            this.Rollback(); // there you go
        }
    }
