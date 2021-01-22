    public static MvcHtmlString ActionButton(this HtmlHelper pHtml, string pAction, string pController, object pRouteValues, string pBtnValue, string pBtnName, string pBtnID)
    {
    	UrlHelper urlHelperForActionLink = new UrlHelper(pHtml.ViewContext.RequestContext);
    	bool flag = Operators.CompareString(pController, "", true) != 0;
    	string actionLink;
    	if (flag)
    	{
    		actionLink = urlHelperForActionLink.Action(pAction, pController, System.Runtime.CompilerServices.RuntimeHelpers.GetObjectValue(pRouteValues));
    	}
    	else
    	{
    		actionLink = urlHelperForActionLink.Action(pAction, System.Runtime.CompilerServices.RuntimeHelpers.GetObjectValue(pRouteValues));
    	}
    	string onClickEventJavascript = "this.form.action = '" + actionLink + "'; this.form.submit();";
    	TagBuilder btnTagBuilder = new TagBuilder("input");
    	btnTagBuilder.MergeAttribute("type", "button");
    	btnTagBuilder.MergeAttribute("onClick", onClickEventJavascript);
    	flag = (Operators.CompareString(pBtnValue, "", true) != 0);
    	if (flag)
    	{
    		btnTagBuilder.MergeAttribute("value", pBtnValue);
    	}
    	flag = (Operators.CompareString(pBtnName, "", true) != 0);
    	if (flag)
    	{
    		btnTagBuilder.MergeAttribute("name", pBtnName);
    	}
    	flag = (Operators.CompareString(pBtnID, "", true) != 0);
    	if (flag)
    	{
    		btnTagBuilder.MergeAttribute("id", pBtnID);
    	}
    	return MvcHtmlString.Create(btnTagBuilder.ToString(TagRenderMode.Normal));
    }
