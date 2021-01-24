    public static IHtmlContent CustomLabelFor<TModel, TProperty>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
    {
        string result;
        TagBuilder div = new TagBuilder("div");
        div.MergeAttribute("class", "form-group");
        var label = helper.LabelFor(expression, new { @class = "control-label col-lg-1" });
        div.InnerHtml.AppendHtml(label);
        using (var sw = new System.IO.StringWriter())
        {
            div.WriteTo(sw, System.Text.Encodings.Web.HtmlEncoder.Default);
            result = sw.ToString();
        }
    
        return new HtmlString(result);
    }
