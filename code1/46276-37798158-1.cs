    DataTable dt = (DataTable)Session["dtAllOrders"];
    DataTable dtSpecificOrders = new DataTable();
    // Create new DataColumns for dtSpecificOrders that are the same as in "dt"
    DataColumn dcID = new DataColumn("ID", typeof(int));
    DataColumn dcName = new DataColumn("Name", typeof(string));
    dtSpecificOrders.Columns.Add(dtID);
    dtSpecificOrders.Columns.Add(dcName);
    
    DataRow[] orderRows = dt.Select("CustomerID = 2");
    foreach (DataRow dr in orderRows)
    {
        DataRow myRow = dtSpecificOrders.NewRow();  // <-- create a brand-new row
        myRow[dcID] = int.Parse(dr["ID"]);
        myRow[dcName] = dr["Name"].ToString();
        dtSpecificOrders.Rows.Add(myRow);   // <-- this will add the new row
    }
