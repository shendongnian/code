    interface ITableDef
    {
        JObject TableDef();
    }
    class UserCollection : ITableDef
    {
       // Stuff
       public JObject TableDef(){ // Todo }
    }
    class EmployeeCollection : ITableDef
    {
       // Stuff
       public JObject TableDef(){ // Todo }
    }
    class TableDefinitions
    {
      public UserCollection Users {get;set;}
      public EmployeeCollection Employees {get;set;}
      // Stuff
    }
    public void RunTableDefMethod(TableDefinitions tableDefinitionsInstance, string propertyName)
    {
        var propInfo = typeof(TableDefinitions).GetProperty(propertyName); // you can cache this
        var instance = propInfo.GetValue(tableDefinitionsInstance) as ITableDef;
        instance.TableDef();
    }
