    SPWeb oWebsite = SPContext.Current.Web;
    SPList oList = oWebsite.Lists["List_Name"];
    SPListItemCollection collListItems = oList.Items;
    
    DataGrid1.DataSource = collListItems.GetDataTable();
    DataGrid1.DataBind();
