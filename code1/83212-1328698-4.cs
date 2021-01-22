    private void Form1_Load(object sender, EventArgs e) 
    {
        String s = String.Empty;
        String sConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;DataSource=unsorted.xls;Extended Properties=""Excel 12.0;HDR=NO;""";
        using (OleDbConnection conn = new OleDbConnection(sConnectionString)) 
        {
            conn.Open();
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            foreach (DataRow schemaRow in schemaTable.Rows) 
            {
                string sheet = schemaRow["TABLE_NAME"].ToString();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                cmd.CommandType = CommandType.Text;
                DataTable outputTable = new DataTable(sheet);
                output.Tables.Add(outputTable);
                new OleDbDataAdapter(cmd).Fill(outputTable);
            }
            // populate string with value from rows
            foreach (DataRow dr in MyDataSet.Tables[0].Rows)
            {
               s = String.Empty ? s += dr[0].ToString() : s += " " + dr[0].ToString(); 
            }       
            dataGridView1.DataSource = dsExcelContent1;        
            objConn.Close();
        }
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
            {                
                Console.WriteLine("'{0}' is not a number!", num);
            }        
        }        
        this.listBox1.DataSource = numberList;
    }
