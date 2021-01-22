    private void Form1_Load(object sender, EventArgs e)
    {            
        SqlConnection cn = new SqlConnection(@"server=.;database=My_dataBase;integrated security=true");
        SqlDataAdapter da = new SqlDataAdapter(@"SELECT [MyColumn] FROM [my_table]", cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
    
        List<string> myList = new List<string>();
        foreach (DataRow row in dt.Rows)
        {
            myList.Add((string)row[0]);
        }
        autoCompleteTextbox1.AutoCompleteList = myList;
    }  
        
