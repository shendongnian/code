    Connection con = new Connection();    
    SqlDataAdapter sda = new SqlDataAdapter("*`<SelectionQuery>`*",con);        
    cmbVendorCode.Items.Clear();
    con.dataGet("Select vendor_code from vendor_master order by vendor_code Asc;");
    DataTable dt = new DataTable();            
    con.sda.Fill(dt);
