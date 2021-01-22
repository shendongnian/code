    // System.Data.SqlClient.SqlConnection.Dispose disassemble
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            this._userConnectionOptions = null;
            this._poolGroup = null;
            this.Close();
        }
        this.DisposeMe(disposing);
        base.Dispose(disposing);
    }
