    private void Button1_Click(object sender, System.EventArgs e) {
            DataTable tblReadCSV = new DataTable();
            tblReadCSV.Columns.Add("FName");
            tblReadCSV.Columns.Add("LName");
            tblReadCSV.Columns.Add("Department");
            TextFieldParser csvParser = new TextFieldParser("C:\\your_path_here\\Employee.txt");
            csvParser.Delimiters = new string[] {
                    ","};
            csvParser.TrimWhiteSpace = true;
            csvParser.ReadLine();
            while (!(csvParser.EndOfData == true)) {
                tblReadCSV.Rows.Add(csvParser.ReadFields());
            }
            
            SqlConnection con = new SqlConnection("Server=your_server_name;Database=your_DB_name;Trusted_Connection=True;");
            string strSql = "Insert into Employee(FName,LName,Department) values(@Fname,@Lname,@Department)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            cmd.Connection = con;
            cmd.Parameters.Add("@Fname", SqlDbType.VarChar, 50, "FName");
            cmd.Parameters.Add("@Lname", SqlDbType.VarChar, 50, "LName");
            cmd.Parameters.Add("@Department", SqlDbType.VarChar, 50, "Department");
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.InsertCommand = cmd;
            int result = dAdapter.Update(tblReadCSV);
        }
