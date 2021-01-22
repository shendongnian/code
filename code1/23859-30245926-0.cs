    private List<string> _lstString;
    public void GetValueByParameter<T>(IDataReader dr, string parameterName, out T returnValue)
    {
        returnValue = default(T);
        if (!_lstString.Contains(parameterName))
        {
            Logger.Instance.LogVerbose(this, "missing parameter: " + parameterName);
            return;
        }
        try
        {
            if (dr[parameterName] != null && [parameterName] != DBNull.Value)
                returnValue = (T)dr[parameterName];
        }
        catch (Exception ex)
        {
            Logger.Instance.LogException(this, ex);
        }
    }
    /// <summary>
    /// Reset the global list of columns to reflect the fields in the IDataReader
    /// </summary>
    /// <param name="dr">The IDataReader being acted upon</param>
    /// <param name="NextResult">Advances IDataReader to next result</param>
    public void ResetSchemaTable(IDataReader dr, bool nextResult)
    {
        if (nextResult)
            dr.NextResult();
        _lstString = new List<string>();
            
        using (DataTable dataTableSchema = dr.GetSchemaTable())
        {
            if (dataTableSchema != null)
            {
                foreach (DataRow row in dataTableSchema.Rows)
                {
                    _lstString.Add(row[dataTableSchema.Columns["ColumnName"]].ToString());
                }
            }
        }
    }
