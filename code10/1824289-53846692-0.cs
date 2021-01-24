            var connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\mybook.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=NO;IMEX=1;\"";
            var OledbConn = new OleDbConnection(connString);
            DataTable schemaTable = new DataTable();
            var OledbCmd = new OleDbCommand();
            OledbCmd.Connection = OledbConn;
            OledbConn.Open();
            OledbCmd.CommandText = "Select * from [StudentDetails$]";
            OleDbDataReader dr = OledbCmd.ExecuteReader();
            DataTable ContentTable = null;
            if (dr.HasRows)
            {
                ContentTable = new DataTable();
                ContentTable.Columns.Add("Name", typeof(string));
                ContentTable.Columns.Add("Email", typeof(string));
                ContentTable.Columns.Add("Company Name", typeof(string));
                ContentTable.Columns.Add("Phone Number", typeof(string));
                while (dr.Read())
                {
                    if (dr[0].ToString().Trim() != string.Empty && dr[1].ToString().Trim() != string.Empty && dr[2].ToString().Trim() != string.Empty && dr[0].ToString().Trim() != " " && dr[1].ToString().Trim() != " " && dr[2].ToString().Trim() != " ")
                        ContentTable.Rows.Add(dr[0].ToString().Trim(), dr[1].ToString().Trim(), dr[2].ToString().Trim(), dr[3].ToString().Trim());
                }
            }
            dr.Close();
        }
