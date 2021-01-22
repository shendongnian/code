    public static class PageCommon
    {
       public static System.Web.Mvc.UrlHelper GetUrlHelper(this System.Web.UI.Control c)
       {
	       var helper = new System.Web.Mvc.UrlHelper(c.Page.Request.RequestContext);
		   return helper;
	   }
	   class ViewDataBag : IViewDataContainer
	   {
			ViewDataDictionary vdd = new ViewDataDictionary();
			public ViewDataDictionary ViewData
			{
				get
				{
					return vdd;
				}
				set
				{
					vdd = value;
				}
			}
		}
		public static System.Web.Mvc.HtmlHelper GetHtmlHelper(this System.Web.UI.Control c)
		{
			var v = new System.Web.Mvc.ViewContext();
			var helper = new System.Web.Mvc.HtmlHelper(v, new ViewDataBag());
			return helper;
		}
