    [WebMethod]
    public static List<CustomListControl.IListItem> GetListItems()
    {
        Page page = HttpContext.Current.Handler as Page;
       
        if (page != null)
        {
            var c = page.FindControl("myList");
        }
        return null;
    }
