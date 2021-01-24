    protected void bindgrid()
    {
    //        gvItems.DataSource = clsobj.getDataTable(@"SELECT 
     ObservationItem.ObsItemID, ObservationItem.ObsID, ObservationItem.ItemID, 
     ObservationItem.GradeID, ObservationItem.Remarks, ObservationItem.IsActive, 
     //                                                            Item_M.ItemID 
     AS ItemIDbind, Item_M.ItemName FROM ObservationItem INNER JOIN Item_M ON 
     ObservationItem.ItemID = Item_M.ItemID where Item_M.IsActive=1");
        gvItems.DataSource = clsobj.getDataTable("Select ItemID,ItemName from 
      Item_M where IsActive=1");
        gvItems.DataBind();
        //--------------------For populating upper gridview with data---------        
     DataTable dt2 = clsobj.getDataTable(@"SELECT ObsItemID, ObsID, ItemID, 
     GradeID, Remarks, IsActive FROM  ObservationItem where ObsID=1");
        if (dt2.Rows.Count > 0)
        {
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                //string ItemID1 = 
      gvItems.DataKeys[i].Values["ItemID"].ToString();                        
                RadioButtonList RDBTop = 
     (RadioButtonList)gvItems.Rows[i].Cells[0].FindControl("RdbGradeTop");
                TextBox TxtRemarks = 
     (TextBox)gvItems.Rows[i].Cells[0].FindControl("txtRemarks");
                RDBTop.SelectedValue = dt2.Rows[i]["GradeID"].ToString();
                TxtRemarks.Text = dt2.Rows[i]["Remarks"].ToString();
            }
        }
        //--------------------For populating upper gridview with data----------
     }
     protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
     {
        DataTable dt1 = new DataTable(),dt=new DataTable();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            dt1 = clsobj.getDataTable("select GradeID,Grade from Grade_M where 
        IsActive=1");
            RadioButtonList rbGradeTop = 
         (RadioButtonList)e.Row.FindControl("RdbGradeTop");
            
            rbGradeTop.DataSource = dt1;
            rbGradeTop.DataTextField = "Grade";
            rbGradeTop.DataValueField = "GradeID";
            rbGradeTop.DataBind();
            string ItemID = gvItems.DataKeys[e.Row.RowIndex].Value.ToString();
            GridView gvSubItem = e.Row.FindControl("gvSubItem") as GridView;
            dt = clsobj.getDataTable(string.Format("select 
            SubItemID,SubItemName,ItemID from SubItem_M where IsActive=1 and 
            ItemID='{0}'", ItemID));
            gvSubItem.DataSource = dt;
            gvSubItem.DataBind();
           // bindtopgridwithdata();
            
        }
        //----------For populating innergridview with data----------------------
        //for (int k; k<dt.Rows.Count; k++)
        //{
        
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
        if (dt.Rows.Count != 0)
        {
            DataTable dt2 = clsobj.getDataTable(@"SELECT 
           ObservationSubItem.ObsSubItemID, ObservationSubItem.ObsItemID, 
            ObservationSubItem.SubItemID, ObservationSubItem.GradeID 
                                                      FROM ObservationSubItem 
          INNER JOIN
                                                      ObservationItem ON 
            ObservationSubItem.ObsItemID = ObservationItem.ObsItemID where 
           ObservationItem.ObsID=1");
            if (dt2.Rows.Count > 0)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    DataTable dt3 = clsobj.getDataTable(@"SELECT 
         ObservationSubItem.ObsSubItemID, ObservationSubItem.ObsItemID, 
         ObservationSubItem.SubItemID, ObservationSubItem.GradeID 
                                                      FROM ObservationSubItem 
          INNER JOIN
                                                      ObservationItem ON 
        ObservationSubItem.ObsItemID = ObservationItem.ObsItemID where 
           ObservationItem.ObsID=1 and ObservationSubItem.ObsItemID=" + i);
                   // GridView GrdvInner = e.Row.FindControl("gvSubItem") as 
        GridView;
                   // int m = 0;
                    if (e.Row.FindControl("gvSubItem") != null) //(i == 
         Convert.ToInt16(dt2.Rows[i]["ObsItemID"].ToString()) && 
           e.Row.RowIndex.Equals(i-1))//// To be chaecked
                    {
                        if (dt3.Rows.Count >0)
                        if (e.Row.RowIndex.Equals(Convert.ToInt16(dt3.Rows[0] 
             ["ObsItemID"].ToString()) - 1))
                        {
                            GridView GrdvInner = e.Row.FindControl("gvSubItem") 
           as GridView; 
            //(GridView)gvItems.Rows[i].Cells[0].FindControl("gvSubItem"); ////- 
             --------- This line is not working--------------------------------- 
                 ------------------------------------
                            for (int j = 0; j < dt3.Rows.Count; j++)
                            {
                                //, e.Row.FindControl("gvSubItem") as GridView;
                                RadioButtonList RDBGrade = 
             
            (RadioButtonList)GrdvInner.Rows[j].Cells[0].FindControl("RdbGrade");
                                RDBGrade.SelectedValue = dt3.Rows[j] 
              ["GradeID"].ToString();
                            }
                        }
                    }
                   // m++;
                }
            }
        }
        }
        //-------------------------or populating innergridview with data--------
