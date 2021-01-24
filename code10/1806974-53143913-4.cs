    int n = SalesRegisterControl.Instance.Sales_Grid.Rows.Add();
    SalesRegisterControl.Instance.Sales_Grid.ClearSelection();
    SalesRegisterControl.Instance.Sales_Grid.Rows[n].Cells[1].Value = dr["Deal_Name"].ToString();
    SalesRegisterControl.Instance.Sales_Grid.Rows[n].Cells[2].Value = dr["Deal_Price"].ToString();
    SalesRegisterControl.Instance.Sales_Grid.Rows[n].Cells[3].Value = 1;
    SalesRegisterControl.Instance.Sales_Grid.Rows[n].Cells[4].Value = dr["Deal_Price"].ToString();
    SalesRegisterControl.Instance.Sales_Grid.Rows[n].Cells[5].Value = "FF";
    
    foreach (DataRow dr in dt.Rows)
    {
    	n = SalesRegisterControl.Instance.Sales_Grid.Rows.Add();
    	SalesRegisterControl.Instance.Sales_Grid.ClearSelection();
    	SalesRegisterControl.Instance.Sales_Grid.Rows[n].Cells[1].Value = dr["Item_Name"].ToString();
    	SalesRegisterControl.Instance.Sales_Grid.Rows[n].Cells[2].Value = 0;
    	SalesRegisterControl.Instance.Sales_Grid.Rows[n].Cells[3].Value = dr["Quantity"].ToString();
    	SalesRegisterControl.Instance.Sales_Grid.Rows[n].Cells[4].Value = 0;
    	SalesRegisterControl.Instance.Sales_Grid.Rows[n].Cells[5].Value = "FF";
    }
