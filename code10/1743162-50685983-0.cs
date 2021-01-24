     This below code helped me find the control and also make the dropdownlist be populated with current values.
 
      protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
            
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
            DropDownList ddlline = (DropDownList)e.Row.FindControl("line1");
            DataTable dt = new DataTable();
            string sql = "Select Distinct Line FROM [WC Info] Where Plant = " + "\'" + PlantVal + "\'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            ddlline.DataSource = dt;
            ddlline.DataTextField = "Line";
            ddlline.DataValueField = "Line";
            ddlline.DataBind();
            DataRowView dr = e.Row.DataItem as DataRowView;
            ddlline.SelectedValue = dr["Line"].ToString();
            DropDownList ddlmachine = (DropDownList)e.Row.FindControl("Machine1");
            DataTable dt1 = new DataTable();
            string sql1 = "Select Distinct [Machine] FROM [WC Info] WHERE Line = '" + ddlline.SelectedValue + "'";
            SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
            da1.Fill(dt1);
            ddlmachine.DataSource = dt1;
            ddlmachine.DataTextField = "Machine";
            ddlmachine.DataValueField = "Machine";
            ddlmachine.DataBind();
            ddlmachine.SelectedValue = dr["Machine"].ToString();
            DropDownList ddlbagtype = (DropDownList)e.Row.FindControl("BagType1");
            DataTable dt2 = new DataTable();
            string sql2 = "Select [Bag Type] FROM [Bag Type]";
            SqlDataAdapter da2 = new SqlDataAdapter(sql2, con);
            da2.Fill(dt2);
            ddlbagtype.DataSource = dt2;
            ddlbagtype.DataTextField = "Bag Type";
            ddlbagtype.DataValueField = "Bag Type";
            ddlbagtype.DataBind();
            ddlbagtype.SelectedValue = dr["Bag Type"].ToString();
            DropDownList ddlprodunit = (DropDownList)e.Row.FindControl("ProdType");
            DataTable dt3 = new DataTable();
            string sql3 = "SELECT [Std Prod# Unit] AS ProdType FROM [WC Info] WHERE Line =" + "\'" + ddlline.SelectedValue + "\'" + "and [Machine] =" + "\'" + ddlmachine.SelectedValue + "\'";
            SqlDataAdapter da3 = new SqlDataAdapter(sql3, con);
            da3.Fill(dt3);
            ddlprodunit.DataSource = dt3;
            ddlprodunit.DataTextField = "ProdType";
            ddlprodunit.DataValueField = "ProdType";
            ddlprodunit.DataBind();
            ddlprodunit.SelectedValue = dr["Prod# Unit"].ToString();
            DropDownList ddlspeedunit = (DropDownList)e.Row.FindControl("SpeedTypeValues1");
            DataTable dt4 = new DataTable();
            string sql4 = "SELECT [Std Speed Unit] FROM [WC Info] WHERE Line =" + "\'" + ddlline.SelectedValue + "\'" + "and [Machine] =" + "\'" + ddlmachine.SelectedValue + "\'";
            SqlDataAdapter da4 = new SqlDataAdapter(sql4, con);
            da4.Fill(dt4);
            ddlspeedunit.DataSource = dt4;
            ddlspeedunit.DataTextField = "Std Speed Unit";
            ddlspeedunit.DataValueField = "Std Speed Unit";
            ddlspeedunit.DataBind();
            ddlspeedunit.SelectedValue = dr["Speed Unit"].ToString();
            }
           }
         }
