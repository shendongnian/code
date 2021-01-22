    public EntityQuery<TableName> GetTableNameByRx_IDQuery(long otherTable_ID)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("otherTable_ID", otherTable_ID);
        return base.CreateQuery<TableName>("GetTableNameByotherTable_ID", parameters, false, true);
    }
