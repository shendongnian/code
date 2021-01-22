    protected virtual void Dispose(bool disposing)
    {
        if (this.WriteState != WriteState.Closed)
        {
            try
            {
                this.Close();
            }
            catch
            {
            }
        }
    }
