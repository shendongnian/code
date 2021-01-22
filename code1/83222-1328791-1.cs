            String sConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=unsorted.xls;Extended Properties=""Excel 12.0;HDR=NO;""";
            OleDbConnection objConn = new OleDbConnection(sConnectionString);
            objConn.Open();
            OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [sheet1$]", objConn);
            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
            objAdapter1.SelectCommand = objCmdSelect;
            DataSet dsExcelContent = new DataSet();
            DataTable dsExcelContent1 = new DataTable();
            objAdapter1.Fill(dsExcelContent);
            dataGridView1.DataSource = dsExcelContent1;
            objConn.Close();
            int test = dsExcelContent.Tables[0].Rows.Count;
            
           foreach(DataRow row in dsExcelContent.Tables[0].Rows)
            {
                StringBuilder builder = new StringBuilder();
                foreach (DataColumn col in dsExcelContent.Tables[0].Columns)
                {
                    builder.Append(row[col].ToString());
                    builder.Append(" ");
                }
                string s = builder.ToString();
                this.label1.Text = s;
                string[] numbers = s.Split(' ');
                ArrayList numberList = new ArrayList();
                int i;
                foreach (String num in numbers)
                {
                    if (Int32.TryParse(num, out i))
                    {
                        numberList.Add(i);
                    }
                    else
                        Console.WriteLine("'{0}' is not a number!", num);
                }
                this.listBox1.DataSource = numberList;
               
            }
            
           
            
        }
    }
