    protected void Page_Load(object sender, EventArgs e) {
        var tb = GetListItems(this);
    }
    
    [WebMethod]
    public static List<CustomListControl.IListItem> GetListItems(System.Web.UI.Page page)
    {
        var c = null;    
    
        if (page != null)
        {
            c = page.FindControl("myList");
        }
        return c;
    }
