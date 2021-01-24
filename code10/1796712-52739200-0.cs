    public static MvcHtmlString PartialFor<TModel, TProperty>(
        this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, 
        string partialViewName)
    {
        var name = ExpressionHelper.GetExpressionText(expression);
        var model = ModelMetadata.FromLambdaExpression(expression, helper.ViewData).Model;
        var viewData = new ViewDataDictionary(helper.ViewData)
        {
            TemplateInfo = new TemplateInfo { HtmlFieldPrefix = name }
        };
        return helper.Partial(partialViewName, model, viewData);
    }
