    internal void CloseFully()
    {
        if (this.settings.Pooling && this.driver.IsOpen)
        {
            if ((this.driver.ServerStatus & ServerStatusFlags.InTransaction) != 0)
            {
                new MySqlTransaction(this, IsolationLevel.Unspecified).Rollback();
            }
            MySqlPoolManager.ReleaseConnection(this.driver);
        }
        else
        {
            this.driver.Close();
        }
        this.driver = null;
    }
