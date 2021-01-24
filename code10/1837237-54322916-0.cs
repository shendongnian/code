    public static class HtmlHelpers
    {
        public static MvcHtmlString DisplayWithBreaksFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var model = html.Encode(metadata.Model).Replace("\r\n", "<br />\r\n");
    
            if (String.IsNullOrEmpty(model))
                return MvcHtmlString.Empty;
    
            return MvcHtmlString.Create(model);
        }
    }
