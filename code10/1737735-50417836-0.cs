    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            //not in an ispostback check
        }
        //but outside when working with dynamic controls
        //create a new table
        Table table = new Table();
        //create a connection and a command
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        using (SqlCommand cmd = new SqlCommand("select * from subjects", conn))
        {
            //open the connection
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    //create a new row, cell and checkbox
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    CheckBox cb = new CheckBox();
                    //set some checkbox properties
                    cb.Text = reader["ColumnName"].ToString();
                    //add the checkbox to the cell
                    cell.Controls.Add(cb);
                    //the cell to the row
                    row.Controls.Add(cell);
                    //and the row to the table
                    table.Controls.Add(row);
                }
            }
        }
        //finally add the table to the page
        PlaceHolder1.Controls.Add(table);
    }
