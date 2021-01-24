    public void BulkCopyToSqlServer()
    {
        var persons = JsonConvert.DeserializeObject<List<Member>>(response);
    
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("res_order_num", typeof(System.String)));
        dt.Columns.Add(new DataColumn("menu_code", typeof(System.String)));
        dt.Columns.Add(new DataColumn("menu_quantity", typeof(System.String)));
        dt.Columns.Add(new DataColumn("menu_total_price", typeof(System.String)));
        dt.Columns.Add(new DataColumn("res_no", typeof(System.String)));
        dt.Columns.Add(new DataColumn("menu_name", typeof(System.String)));
    
        foreach (var item in persons)
        {
            DataRow dr = dt.NewRow();
            dr["res_order_num"] = item.res_order_num;
            dr["menu_code"] = item.menu_code;
            dr["menu_quantity"] = item.menu_quantity;
            dr["menu_total_price"] = item.menu_total_price;
            dr["res_no"] = item.res_no;
            dr["menu_name"] = item.menu_name;
            dt.Rows.Add(dr);
        }
    
    
        MySqlConnection con = new MySqlConnection("Your Connection String");
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        MySqlCommand cmd = new MySqlCommand("Your Insert Command", con);
        cmd.CommandType = CommandType.Text;
    
        cmd.UpdatedRowSource = UpdateRowSource.None;
    
        MySqlDataAdapter da = new MySqlDataAdapter();
        da.InsertCommand = cmd;
        da.UpdateBatchSize = 100000; //If you json contains 100000 persons object;
        int records = da.Update(dt);
        con.Close();
    }
