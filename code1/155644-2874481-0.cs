    public static MvcHtmlString RenderMenu(this HtmlHelper html) {
                var somePage = Html.ViewContext.HttpContext.Request.RawUrl;
		        var menu = lookupMenuBasedOnPage(somePage);
                return MvcHtmlString.Create(menu.Render());
	}
