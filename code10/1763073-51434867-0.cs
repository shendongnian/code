    string WorkBookPath = @"D:\Test\Book1.xlsx";  //@"E:\students.xlsx";
    string SheetName = "Sheet1$"; // <--- this is the name of the WORKSHEET in the workBOOK
    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + WorkBookPath + ";Extended Properties=Excel 12.0;";
    using (OleDbConnection con = new OleDbConnection(constr)) {
      OleDbDataAdapter sda = new OleDbDataAdapter("Select * From [" + SheetName + "]", con);
      DataTable data = new DataTable();
      sda.Fill(data);
      dataGridView1.DataSource = data;
    }
