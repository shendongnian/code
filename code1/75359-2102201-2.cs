    /// <summary>
    /// Set the Select command timeout for a Table Adapter
    /// </summary>
    public static void TableAdapterCommandTimeout<T>(this T TableAdapter, int CommandTimeout) where T : global::System.ComponentModel.Component
    {                
        foreach (var c in typeof(T).GetProperty("CommandCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.Instance).GetValue(TableAdapter, null) as System.Data.SqlClient.SqlCommand[])
            c.CommandTimeout = CommandTimeout;
    }
