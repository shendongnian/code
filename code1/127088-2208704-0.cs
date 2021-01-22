        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c://Org.xls;Extended Properties=" + (char)34 + "Excel 8.0;HDR=Yes;" + (char)34);
        DataSet myExcelData=new DataSet();
        conn.Open();
        OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [Sheet1$]", conn);
        myDataAdapter.Fill(myExcelData);
        ultraGrid1.DataSource = myExcelData;
        
        conn.Close(); 
