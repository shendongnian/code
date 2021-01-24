    SqlConnection conn = new SqlConnection("server=***;database=***;user id=***;password=***");
    SqlDataAdapter da = new SqlDataAdapter();
    SqlCommand cmd = conn.CreateCommand();
    cmd.CommandText = "select column1 , column2 from dbo.myTable";
    da.SelectCommand = cmd;
    DataSet ds = new DataSet();
    
    conn.Open();
    da.Fill(ds);
    this.ChartExample.DataSource = ds.Tables[0];
    //Mapping a field with x-value of chart
    this.ChartExample.Series[0].XValueMember = "column1";
    //Mapping a field with y-value of Chart
    this.ChartExample.Series[0].YValueMembers = "column2";
    //Bind the DataTable with Chart
    this.ChartExample.DataBind();
         
    conn.Close();
