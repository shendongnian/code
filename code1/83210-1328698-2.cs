    private void Form1_Load(object sender, EventArgs e) 
    { 
        String sConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; DataSource=unsorted.xls;Extended Properties=""Excel 12.0;HDR=NO;""";
        OleDbConnection objConn = new OleDbConnection(sConnectionString);
        objConn.Open();        
        OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [sheet1$]", objConn);        
        OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
        objAdapter1.SelectCommand = objCmdSelect;        
        DataSet dsExcelContent = new DataSet();        
        DataTable dsExcelContent1 = new DataTable();        
        objAdapter1.Fill(dsExcelContent);
        // populate string with value from rows
        string s = String.Empty;
        foreach (DataRow dr in MyDataSet.Tables[0].Rows)
        {
           s = String.Empty ? s += dr[0].ToString() : s += " " + dr[0].ToString(); 
        }       
        dataGridView1.DataSource = dsExcelContent1;        
        objConn.Close();        
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
