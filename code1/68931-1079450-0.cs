    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            this.OutStream.Close();
        }
    }
 
 
