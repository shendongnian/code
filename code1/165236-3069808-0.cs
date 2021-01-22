    using System; 
    using System.Linq.Expressions; 
    using System.Web.Mvc; 
     
    namespace MvcLibrary.Extensions 
    { 
        public static class HtmlExtensions 
        { 
            public static MvcHtmlString FieldIdFor<TModel, TValue>(this HtmlHelper<TModel> html,
                Expression<Func<TModel, TValue>> expression) 
            { 
                string htmlFieldName = ExpressionHelper.GetExpressionText(expression); 
                string inputFieldId = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName); 
                return MvcHtmlString.Create(inputFieldId); 
            } 
        } 
    }
