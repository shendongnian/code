    using System.Web.Mvc;
    using Microsoft.Web.Mvc;
    public static class HtmlExtensions
    {
        public static MvcHtmlString EditorForIsInStock(this HtmlHelper<Product> htmlHelper)
        {
            var tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttribute("type", "checkbox");
            tagBuilder.MergeAttribute("name", htmlHelper.NameFor(x => x.IsInStock).ToHtmlString());
            if (htmlHelper.ViewData.Model.IsInStock)
            {
                tagBuilder.MergeAttribute("checked", "checked");
            }
            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }
