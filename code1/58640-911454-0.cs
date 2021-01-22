    protected override void Dispose(bool disposing)
    {
        try
        {
            // Not relevant things
        }
        finally
        {
            if (this.Closable && (this.stream != null))
            {
                try
                {
                    if (disposing)
                    {
                        this.stream.Close();
                    }
                }
                finally
                {
                    // Not relevant things
                }
            }
        }
    }
