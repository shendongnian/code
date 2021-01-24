    public JsonResult SaveTestData(string itemCode, int quantity)
    {
        DataTable dt = new DataTable("tblTest"); // Declare as Global.
        // A table saved in session
        if (Session["tblTest"] != null)
        {
            dt = (DataTable)Session["tblTest"];
        }
        else // create new table and store in session
        {
            dt.Columns.Add("ItemCode", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
        }
        
        
        DataRow dr;
        dr = dt.NewRow();
        dr["ItemCode"] = itemCode;
        dr["Quantity"] = quantity;
        dt.Rows.Add(dr);
        //store new row in session
        Session["tblTest"] = dt;
        return Json(1);
    }
