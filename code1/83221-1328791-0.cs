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
            string s = ++ WHAT TO DO HERE TO ACHIEVE WHAT I WANT++++
           
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
