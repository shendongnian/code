    string sql = "SELECT scan_typeclass from scan_types WHERE scan_typeid = " + scan_typeid.ToString();
    sqlconn3.Open();
    SqlCommand cmd = new SqlCommand(sql, sqlconn3);
    SqlDataReader drScanClass = cmd.ExecuteReader(CommandBehavior.CloseConnection);
    drScanClass.Read();
            
    var scan_class = "SharedAuditSVC." + drScanClass["scan_typeclass"].ToString();
            
    Type[] argTypes = new Type[] { typeof(System.Int32), typeof(System.String), typeof(System.Int32), typeof(System.Data.SqlClient.SqlDataReader) };
    object[] argVals = new object[] { scan_id, scan_name, scan_typeid, drActiveServers };
    var type = Type.GetType(scan_class);
    ConstructorInfo cInfo = type.GetConstructor(argTypes);
    var myObject = cInfo.Invoke(argVals);
