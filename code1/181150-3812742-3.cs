    public static class SelectExtensions
    {
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string selectedValue, string optionLabel)
        {
            return DropDownListFor(helper, expression, selectList, selectedValue, optionLabel, null);
        }
    
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string selectedValue, string optionLabel, object htmlAttributes)
        {
            return DropDownListHelper(helper, ExpressionHelper.GetExpressionText(expression), selectList, selectedValue, optionLabel, new RouteValueDictionary(htmlAttributes));
        }
    
        /// <summary>
        /// This is almost identical to the one in ASP.NET MVC 2 however it removes the default values stuff so that the Selected property of the SelectListItem class actually works
        /// </summary>
        private static MvcHtmlString DropDownListHelper(HtmlHelper helper, string name, IEnumerable<SelectListItem> selectList, string selectedValue, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            name = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
    
            // Convert each ListItem to an option tag
            var listItemBuilder = new StringBuilder();
    
            // Make optionLabel the first item that gets rendered
            if (optionLabel != null)
                listItemBuilder.AppendLine(ListItemToOption(new SelectListItem() { Text = optionLabel, Value = String.Empty, Selected = false }, selectedValue));
    
            // Add the other options
            foreach (var item in selectList)
            {
                listItemBuilder.AppendLine(ListItemToOption(item, selectedValue));
            }
    
            // Now add the select tag
            var tag = new TagBuilder("select") { InnerHtml = listItemBuilder.ToString() };
            tag.MergeAttributes(htmlAttributes);
            tag.MergeAttribute("name", name, true);
            tag.GenerateId(name);
    
            // If there are any errors for a named field, we add the css attribute
            ModelState modelState;
    
            if (helper.ViewData.ModelState.TryGetValue(name, out modelState))
            {
                if (modelState.Errors.Count > 0)
                    tag.AddCssClass(HtmlHelper.ValidationInputCssClassName);
            }
    
            return tag.ToMvcHtmlString(TagRenderMode.Normal);
        }
    
        internal static string ListItemToOption(SelectListItem item, string selectedValue)
        {
            var tag = new TagBuilder("option") { InnerHtml = HttpUtility.HtmlEncode(item.Text) };
    
            if (item.Value != null)
                tag.Attributes["value"] = item.Value;
    
            if ((!string.IsNullOrEmpty(selectedValue) && item.Value == selectedValue) || item.Selected)
                tag.Attributes["selected"] = "selected";
    
            return tag.ToString(TagRenderMode.Normal);
        }
    }
