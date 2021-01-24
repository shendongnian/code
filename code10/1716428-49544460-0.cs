    public static IHtmlString ImageFor<TModel, TValue>(this HtmlHelper<TModel> html,
        Expression<Func<TModel, TValue>> imagePath)
    {
        ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
        // Get the property name
        string name = ExpressionHelper.GetExpressionText(expression);
        // Get the property type
        Type type = metadata.ModelType;
        // Get the property value
        object value = metadata.Model;
