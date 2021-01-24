    public static MvcHtmlString Tooltip<TModel, TValue>(
        this HtmlHelper<TModel> helper, 
        Expression<Func<TModel, TValue>> expression, 
        object htmlAttributes) // Note the signature change.
    {
        // ... snip
        var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
        label.MergeAttributes(attributes);
        // ... snip
    }
