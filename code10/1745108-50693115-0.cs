    public void InsertTest(string test1,string test2, DateTime? date1,DateTime? 
    date2)
    {
     var params= new DynamicParameters(
            new
            {enter code here
     test1= "",
     test2 ="",`enter code here`
     Date1 = cDate.HasValue ? cDate.Value.Date :   DateTime.MinValue.Date,
     Date2 = cDate1.HasValue ? cDate2.Value.Date :   DateTime.MinValue.Date,
 
     }
     ExecConn(SqlQuery , params);
     }
