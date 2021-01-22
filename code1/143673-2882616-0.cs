    Axapta ax = new Axapta();
    ax.Logon("", "", "", "");
            
    //Create a query object based on the customer group query in the AOT
    AxaptaObject query = ax.CreateAxaptaObject("Query", "CustGroupSRS");
    //Create a queryrun object based on the query to fecth records
    AxaptaObject queryRun = ax.CreateAxaptaObject("QueryRun", query);
    AxaptaRecord CustGroup = null;
    ;
    while (Convert.ToBoolean(queryRun.Call("next")))
    {
        //GetTableId function is defined here: <a href="http://stackoverflow.com/questions/2861252/in-dynamics-ax-using-the-business-connector-how-do-you-call-kernel-functions">.Net Business Connector Kernel Functions</a>
        CustGroup = (AxaptaRecord)queryRun.Call("get", ax.GetTableId("CustGroup"));
        System.Diagnostics.Debug.WriteLine(CustGroup.get_Field("Name").ToString());
    }
    CustGroup.Dispose();
    queryRun.Dispose();
    query.Dispose();
    ax.Logoff();
    ax.Dispose();
