    SqlDataAdapter d2 = new SqlDataAdapter("select MARK_PARTA from  exam_cyctstmarkdet",con);
    DataSet dst = new DataSet();
    d2.Fill(dst); // now you have a populated DataSet containing a DataTable
    DataTable dt = dst.Tables[0]; // I created this variable for clarity; you don't really need it
    
    DataColumn c = new DataColumn();                      
    c.ColumnName = "parta";
    c.DataType = System.Type.GetType("System.Int32");
    
    dt.Add(c);
