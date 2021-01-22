    if (tbl.Rows.Count > 0)
    {
          AdminViewBuyersGV.DataSource = tbl;
          AdminViewBuyersGV.DataBind();
    }
    else
     {
      // no records
     }
