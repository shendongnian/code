.
    using System.Web.UI.HtmlControls;
    // ...
    List<HtmlMeta> metas = new List<HtmlMeta>();
    foreach (Control c in this.Page.Header.Controls)
    	if (c.GetType() == typeof(HtmlMeta))
    	{
    		HtmlMeta meta = (HtmlMeta)c;
    		if (meta.Name == "Keywords")
    			meta.Content = "content goes here";
    		break;
    	}
