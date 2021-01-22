    private static T Populate<T>(DataRow dataRow)
         where T : class, IDataStorable, new()
    {
        DBObjectRetrieveAttribute ora =
            ReflectionHelper.GetAttribute<DBObjectRetrieveAttribute>(typeof(T));
        string view = ora.View;
        Guid pkid = new Guid(dataRow[ora.PrimaryKey].ToString());
        // beware SQL injection...
        string query = string.Format("select * from {0} where id = '{1}'",
             view, pkid);
        return DataAccess.Retriever.Retrieve<T>(query);
    }
