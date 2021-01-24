    public static MvcHtmlString LabelFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
    {
        string result = string.Empty;
        var modelMetaData = expression.Compile().Invoke(helper.ViewData.Model);
        string fieldName = ExpressionHelper.GetExpressionText(expression);
        var containerType = typeof(TModel);
        var containerProperties = containerType.GetProperties();
        var propertyInfo = containerProperties.SingleOrDefault(x => x.Name == modelMetaData.PropertyName);
        var attribute = propertyInfo.GetCustomAttributes(false).SingleOrDefault(x => x is DisplayWhenAttribute) as DisplayWhenAttribute;
        var target = attribute.PropertyName; // target property name, e.g. ColorId
        var condition1 = attribute.Condition1; // first value to check
        var condition2 = attribute.Condition2; // second value to check
        
        var targetValue = (int)containerType.GetProperty(target).GetValue(helper.ViewData.Model);  
        // checking provided values from attribute
        if (targetValue == condition1 || targetValue == condition2)
        {
            result = attribute.TrueValue;
        }      
        else
        {
            result = attribute.FalseValue;
        }
        // create <label> tag with specified true/false value
        TagBuilder tag = new TagBuilder("label");
        tag.MergeAttributes(htmlAttributes);
        tag.Attributes.Add("for", helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(fieldName));
        tag.SetInnerText(result);
        return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
    }
