    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        Repeater rp = (Repeater)e.Row.FindControl("RepeatCountry");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            dsCountryByTripID.SelectParameters.Clear();
            DataRowView drv = (DataRowView)e.Row.DataItem;
            string tripID = (drv["pkiTripId"]).ToString();
            dsCountryByTripID.SelectParameters.Clear();
            dsCountryByTripID.SelectParameters.Add("tripID", DbType.Int32, tripID);
            
            rp.DataBind();
        }
    }
