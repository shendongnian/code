    protected override void Dispose(bool disposing)
    {
           if (disposing)
           {
                 switch (this._objectState)
                 {
                       case ConnectionState.Open:
                       {
                             this.Close();
                             break;
                       }
                 }
                 this._constr = null;
           }
           base.Dispose(disposing);
    }
    
    Odbc:
    protected override void Dispose(bool disposing)
    {
           if (disposing)
           {
                 this._constr = null;
                 this.Close();
                 CNativeBuffer buffer1 = this._buffer;
                 if (buffer1 != null)
                 {
                       buffer1.Dispose();
                       this._buffer = null;
                 }
           }
           base.Dispose(disposing);
    }
    
    OleDb:
    protected override void Dispose(bool disposing)
    {
           if (disposing)
           {
                 if (this.objectState != 0)
                 {
                       this.DisposeManaged();
                       if (base.DesignMode)
                       {
                             OleDbConnection.ReleaseObjectPool();
                       }
                       this.OnStateChange(ConnectionState.Open, ConnectionState.Closed);
                 }
                 if (this.propertyIDSet != null)
                 {
                       this.propertyIDSet.Dispose();
                       this.propertyIDSet = null;
                 }
                 this._constr = null;
           }
           base.Dispose(disposing);
    }
