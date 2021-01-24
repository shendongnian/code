    Func<string, string> MaskingFnc = (string ssnParam) => string.Format("XXX-XX-{0}", ssnParam.Substring(4,6));
    
    DataTable employeeTable = new DataTable();
    employeeTable.Columns.Add("SSN")
    employeeTable.Columns.Add("SSNMasked")
    employeeTable.Rows.Add("123455789", MaskingFnc("123455789"));
    employeeTable.Rows.Add("123447789", MaskingFnc("123447789"));
    employeeTable.Rows.Add("823456719", MaskingFnc("823456719"));
