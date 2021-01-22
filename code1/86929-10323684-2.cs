    HtmlExtensions.cs
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
    public static MvcHtmlString DropDownListUnobtrusiveFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
    {
        return DropDownListUnobtrusiveFor(htmlHelper, expression, selectList, null /* optionLabel */, null /* htmlAttributes */);
    }
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
    public static MvcHtmlString DropDownListUnobtrusiveFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
    {
        return DropDownListUnobtrusiveFor(htmlHelper, expression, selectList, null /* optionLabel */, new RouteValueDictionary(htmlAttributes));
    }
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
    public static MvcHtmlString DropDownListUnobtrusiveFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
    {
        return DropDownListUnobtrusiveFor(htmlHelper, expression, selectList, null /* optionLabel */, htmlAttributes);
    }
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
    public static MvcHtmlString DropDownListUnobtrusiveFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel)
    {
        return DropDownListUnobtrusiveFor(htmlHelper, expression, selectList, optionLabel, null /* htmlAttributes */);
    }
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
    public static MvcHtmlString DropDownListUnobtrusiveFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
    {
        return DropDownListUnobtrusiveFor(htmlHelper, expression, selectList, optionLabel, new RouteValueDictionary(htmlAttributes));
    }
    
    [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Users cannot use anonymous methods with the LambdaExpression type")]
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
    public static MvcHtmlString DropDownListUnobtrusiveFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
    {
        if (expression == null)
        {
            throw new ArgumentNullException("expression");
        }
        ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
        IDictionary<string, object> validationAttributes = htmlHelper
            .GetUnobtrusiveValidationAttributes(ExpressionHelper.GetExpressionText(expression), metadata);
        if (htmlAttributes == null)
            htmlAttributes = validationAttributes;
        else
            htmlAttributes = htmlAttributes.Concat(validationAttributes).ToDictionary(k => k.Key, v => v.Value);
        return SelectExtensions.DropDownListFor(htmlHelper, expression, selectList, optionLabel, htmlAttributes);
    }
