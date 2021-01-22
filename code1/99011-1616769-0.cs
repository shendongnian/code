    using (DataView dv = dtProductGroup.DefaultView)
    {
       if (! IsPostBack) {
            dv.ApplyDefaultSort = false; 
            dv.Sort = "KVIGroupName ASC";
    
            ddlGroup.ClearSelection();
            ddlGroup.Items.Clear();
    
            string strAll = Localization.GetResourceValue("_strddlStatusLBAll");
            ddlGroup.DataValueField = "KVIGroupId";
            ddlGroup.DataTextField = "KVIGroupName";
            ddlGroup.DataSource = dv;
            ddlGroup.DataBind();
    
            ListItem item = new ListItem(strAll, "0");
            ddlGroup.Items.Insert(0, item); 
       }
    }
