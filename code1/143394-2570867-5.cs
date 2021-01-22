    using System.Data;
    // create a new collection that will hold all empid keys in emp
    var empidList = new List<string>();
    // open a database connection -- you need to add appropriate code here:
    using (IDbConnection db = ...)
    {
        // define the query for retrieving all empid keys:
        IDbCommand getEmpidList = db.CreateCommand();
        getEmpidList.CommandType = CommandType.Text;
        getEmpidList.CommandText = "SELECT empid FROM emp ORDER BY empid ASC";
        // execute the query and transfer its result set to the collection:
        using (IDataReader reader = getEmpidList.ExecuteReader())
        {
            while (reader.Read())
            {
                empidList.Add(reader.GetString(0));
            }
        }
    }
