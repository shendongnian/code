    [ServiceContract]
    public interface ITableProvider
    {
        [OperationContract]
        DataTable GetTbl();
    }
    [OperationBehavior]
    public DataTable GetTbl(){
        DataTable tbl = new DataTable("testTbl");
        //Populate table with SQL query
        return tbl;
    }
