    protected void bindGridView(GridView gv)
    {
        using(DataTable dt = getData())
        {
            DataColumn dc_Total = new DataColumn("Total");
            DataColumn dc_Rank = new DataColumn("Rank");            
            dt.Columns.Add(dc_Total);
            dt.Columns.Add(dc_Rank);
            dc_Rank.SetOrdinal(1);
            dc_Total.SetOrdinal(2);
            foreach (DataRow dr in dt.Rows)
            {
                dr["Total"] = Convert.ToDouble(dr["A_B_PERC"].ToString()) + Convert.ToDouble(dr["C_PERC"].ToString());
            }
            dt.DefaultView.Sort = "Total";
    		using(DataView dv = dt.DefaultView)
    		{
    			int rank = 1;
    			foreach (DataRowView drv in dv)
    			{
    				drv["Rank"] = rank;
    				rank++;
    			}
    			gv.DataSource = dv;
    			gv.DataBind();
    		}
        }
    }
