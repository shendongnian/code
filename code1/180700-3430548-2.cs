    using System.Linq;
    using System.Web.Mvc;
    using System;
    using System.Text;
    using System.Web.Mvc.Html; //Need this for Html helper extension method
    public static class GroupViewHelper
    {
        public static void ShowContactInfo(this HtmlHelper helper, ModelType model)
        {
            if (model.Group.IsPremium && null != model.Group.ContactInfo)
            {
                helper.RenderPartial("ContactInfo", Model.Group.ContactInfo);
            }
        }
       // ... your other ViewHelper methods here.
    }
