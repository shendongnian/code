    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString TextBoxFor(this HtmlHelper htmlHelper, Expression<Func<TModel, TProperty>> expression, string cssClass, bool disabled)
        {
            return disabled 
                ? Html.TextBoxFor(expression, new {@class=cssClass, disabled="disabled"})
                : Html.TextBoxFor(expression, new {@class=cssClass})
        }
    }
