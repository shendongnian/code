    public void getConnstringfromASP(ADODB.Connection getadoObjConn)
    {
        string strAdoObjConnString = getadoObjConn.ConnectionString; 
        
        SqlConnection objConnection = new SqlConnection(strAdoObjConnString); 
        
    }
