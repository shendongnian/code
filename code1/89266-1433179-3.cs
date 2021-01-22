    // fill data source names
    DevToolShed.OdbcDataSourceManager dsnManager = new DevToolShed.OdbcDataSourceManager();
    System.Collections.SortedList dsnList = dsnManager.GetAllDataSourceNames();
    for (int i = 0; i < dsnList.Count; i++)
    {
        string sName = (string)dsnList.GetKey(i);
        DevToolShed.DataSourceType type = (DevToolShed.DataSourceType)dsnList.GetByIndex(i);
        cbxDataSourceName.Items.Add(sName + " - (" + type.ToString() + " DSN)");
    }
