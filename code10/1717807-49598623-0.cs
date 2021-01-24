    private static MvcHtmlString SelectInternal(this HtmlHelper htmlHelper, ModelMetadata metadata,
    	string optionLabel, string name, IEnumerable<SelectListItem> selectList, bool allowMultiple,
    	IDictionary<string, object> htmlAttributes)
    {
    	string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
    	if (String.IsNullOrEmpty(fullName))
    	{
    		throw new ArgumentException(MvcResources.Common_NullOrEmpty, "name");
    	}
    
    	bool usedViewData = false;
    
    	// If we got a null selectList, try to use ViewData to get the list of items.
    	if (selectList == null)
    	{
    		selectList = htmlHelper.GetSelectData(name);
    		usedViewData = true;
    	}
    	....etc
    }
