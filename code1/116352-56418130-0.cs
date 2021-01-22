    DataTable consolidatedEmployees = new DataTable();
    foreach(ConnectionStringSettings cs in ConfigurationManager.ConnectionStrings)
    {
        consolidatedEmployees.Merge(
              SelectTransaction("select * from employees", cs.ConnectionString));
    }
