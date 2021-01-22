    DataGridTableStyle ts = new DataGridTableStyle();
    ts.MappingName = "Order";
    // Order date column style
    DataGridColumnStyle cust_id = new DataGridTextBoxColumn();
    cust_id.MappingName = "cust_id";
    cust_id.HeaderText = "ID";
    //Hide Customer ID
    cust_id.Width = -1;
    ts.GridColumnStyles.Add(cust_id);
    // Shipping name column style
    DataGridColumnStyle cust_name = new DataGridTextBoxColumn();
    cust_name.MappingName = "cust_name";
    cust_name.HeaderText = "Customer";
    cust_name.Width = 500;
    ts.GridColumnStyles.Add(cust_name);
    GridView1.TableStyles.Add(ts);
