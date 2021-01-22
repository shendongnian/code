    using System.Web.Mvc;
    namespace ASP {
      public static class InputExtensionsOverride {
        public static MvcHtmlString TextBox(this HtmlHelper htmlHelper, string name) {
          TagBuilder tagBuilder = new TagBuilder("input");
          tagBuilder.Attributes.Add("type", "text");
          tagBuilder.Attributes.Add("name", name);
          tagBuilder.Attributes.Add("crazy-override", "true");
          return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.Normal));
        }
      }
    }
