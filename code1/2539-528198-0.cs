    public static string GetUrl(int id)
    {
    	string path = VirtualPathUtility.ToAbsolute("~/SomePage.aspx");
    	return string.Format("{0}?id={1}", path, id);
    }
