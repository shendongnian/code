    public void GetAppLock(string lockName)
    {
        var sql = "exec sp_getapplock @lockName, 'exclusive';";
        var pLockName = new SqlParameter("@lockName", SqlDbType.NVarChar, 255);
        pLockName.Value = lockName;
        this.Database.ExecuteSqlCommand(sql, pLockName);
    }
