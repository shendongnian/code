            /* example table
             * 
    Create  Table Zzztab(Deptno Number, Deptname Varchar2(50) , Loc Varchar2(50) , State Varchar2(2) , Idno Number(10)) ;
    /
    insert into Zzztab(Deptno , Deptname  , Loc  , State , Idno)
    values (0,'Zero','US','NY',0);
    insert into Zzztab(Deptno , Deptname  , Loc  , State , Idno)
    values (1,'One','CA','ON',1);
    insert into Zzztab(Deptno , Deptname  , Loc  , State , Idno)
    values (2,'Three','IS',null,2);
    insert into Zzztab(Deptno , Deptname  , Loc  , State , Idno)
    values (3,'Four','BD',null,3);
             */
        string connectStr = GetConnectionString();
        // Initialize array of data
        String[] myArrayDeptName = { "Zero", "Three", "Four" };
        OracleConnection connection = new OracleConnection(connectStr);
        OracleCommand command = new OracleCommand();
        command.Connection = connection;
        command.CommandType = CommandType.Text ;
        command.CommandText = "begin open :cur for SELECT DEPTNO, DEPTNAME FROM ZZZTAB WHERE DEPTNAME = :DEPT; end;";
        command.ArrayBindCount = myArrayDeptName.Length ;
        command.BindByName = true;
        OracleParameter cur = new OracleParameter("cur", OracleDbType.RefCursor );
        cur.Direction = ParameterDirection.Output;
        cur.Value = myArrayDeptName;
        command.Parameters.Add(cur);
        // deptname parameter
        OracleParameter deptNameParam = new OracleParameter("DEPT", OracleDbType.Varchar2);
        deptNameParam.Direction = ParameterDirection.Input;
        deptNameParam.Value = myArrayDeptName;
        command.Parameters.Add(deptNameParam);
         try
        {
            connection.Open();
            command.ExecuteNonQuery();
            foreach (Oracle.DataAccess.Types.OracleRefCursor  rc in (Oracle.DataAccess.Types.OracleRefCursor[])cur.Value)
            { ...  fill in an join the datatables
