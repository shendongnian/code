    DataTable dt = new DataTable("EMPLOYEE_LIST");
    
    DataColumn eeCode = dt.Columns.Add("EMPLOYEE_CODE", Type.GetType("System.String"));
    DataColumn taxYear = dt.Columns.Add("TAX_YEAR", Type.GetType("System.String"));
    DataColumn intData = dt.Columns.Add("INT_DATA", Type.GetType("System.Int32"));
    DataColumn textData = dt.Columns.Add("TEXT_DATA", Type.GetType("System.String"));
    
    dt.PrimaryKey = new DataColumn[] { eeCode, taxYear };
