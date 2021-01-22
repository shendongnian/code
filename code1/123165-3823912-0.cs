        public static MvcHtmlString CkEditor(this HtmlHelper htmlHelper, string name, string value, object htmlAttributes)
        {
            var output = htmlHelper.TextArea(name, value, htmlAttributes).ToString();
            output += string.Format("<script type=\"text/javascript\">$(document).ready(function(){{ $('#{0}').ckeditor(); }});</script>", name);
            return MvcHtmlString.Create(output);
        }
        public static MvcHtmlString CkEditor(this HtmlHelper htmlHelper, string name, string value)
        {
            return htmlHelper.CkEditor(name, value, null);
        }
        public static MvcHtmlString CkEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes) where TModel : class
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return htmlHelper.CkEditor(metadata.PropertyName, metadata.Model as string, htmlAttributes);
        }
        public static MvcHtmlString CkEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression) where TModel : class
        {
            return htmlHelper.CkEditorFor(expression, null);
        }
