    [ServiceContract]
    public interface ITableProvider 
    {
        [OperationContract]
        DataTable GetTbl();
    }
     
    [OperationBehavior]
    public DataTable GetTbl(){    
        DataTable tbl = new DataTable("testTbl");    
        //populate table with sql query    
        return tbl;
    }
