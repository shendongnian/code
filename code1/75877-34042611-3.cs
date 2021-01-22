    DataTable dt = new DataTable("EMPLOYEE_LIST");
    
    DataColumn eeCode = dt.Columns.Add("EMPLOYEE_CODE", typeof(String));
    DataColumn taxYear = dt.Columns.Add("TAX_YEAR", typeof(String));
    DataColumn intData = dt.Columns.Add("INT_DATA", typeof(int));
    DataColumn textData = dt.Columns.Add("TEXT_DATA", typeof(String));
    
    dt.PrimaryKey = new DataColumn[] { eeCode, taxYear };
