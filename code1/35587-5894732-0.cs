    DataTable IHorizonCLService.RetrieveChangeLog(int iId)
    {
       DataTable dt = new DataTable(); //create new DataTable to be returned by this web method
       dt.Merge(HorMan.RetrieveChangeLog(iId)); //get typed DataTable and fills the DataTable 
       dt.TableName = "SurChangeLogHor"; //assigns name
       return dt;
    }
 
