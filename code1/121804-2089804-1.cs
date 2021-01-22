    public void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                excel.Quit();   
            }
             
            disposed = true;
        }
    }
