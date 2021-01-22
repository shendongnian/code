       DataRowView drv = ((DataRowView)e.Row.DataItem);
       GridView InnerGridView= (GridView)e.Row.FindControl("InnerGridView");
       if (InnerGridView!=null)
         {
              string GroupName = drv["GroupName"]; // to get the GropName. 
              InnerGridView.DataSource = "Query WRT the GroupName";
              InnerGridView.DataBind();
         }
    }
