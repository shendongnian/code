        if (txtHidden_Terms_And_delivery1.Value != "")
        {
            string strHidden_Terms_And_Delivery_Id = "";
            if (ViewState["intTerms_Of_Delivery_Id"] != null)
            {
                strHidden_Terms_And_Delivery_Id = ViewState["intTerms_Of_Delivery_Id"].ToString();
            }
            if (strHidden_Terms_And_Delivery_Id != txtHidden_Terms_And_delivery1.Value)
            {
                ViewState["intTerms_Of_Delivery_Id"] = Convert.ToInt32(txtHidden_Terms_And_delivery1.Value);
                Parameterised_SQL_Dentry pm = new Parameterised_SQL_Dentry(1, CommonStrings.ConnectionString);
                string str_Select = "select  vcrTerm_1,vcrTerm_2,vcrTerm_3,vcrTerm_4,vcrTerm_5,vcrTerm_6 from exp_mst_Terms_Of_Delivery where intTerms_Of_Delivery_Id=@intTerms_Of_Delivery_Id";
                pm.Parameters.Add("@intTerms_Of_Delivery_Id", SqlDbType.Int, txtHidden_Terms_And_delivery1.Value);
                DataTable dt = new DataTable();
                dt = pm.GetDataTable(str_Select);
                if (dt.Rows.Count > 0)
                {
                    txtPacking_List_Notify_Terms1.Text = dt.Rows[0]["vcrTerm_1"].ToString();
                    txtPacking_List_Notify_Terms2.Text = dt.Rows[0]["vcrTerm_2"].ToString();
                    txtPacking_List_Notify_Terms3.Text = dt.Rows[0]["vcrTerm_3"].ToString();
                    txtPacking_List_Notify_Terms4.Text = dt.Rows[0]["vcrTerm_4"].ToString();
                    txtPacking_List_Notify_Terms5.Text = dt.Rows[0]["vcrTerm_5"].ToString();
                    txtPacking_List_Notify_Terms6.Text = dt.Rows[0]["vcrTerm_6"].ToString();
                }
            }
        }
        txtHidden_Terms_And_delivery1.Value = "";
    }
  
