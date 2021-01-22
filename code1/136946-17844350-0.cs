    using System.Web.UI.HtmlControls;
    namespace ProjectName.Calendar
    {
        internal static class Styles
        {
            public const string main = "ProjectName.Styles.main.css";
            public const string calendar = "ProjectName.Styles.calendar.css";
        }
        internal static class Scripts
        {
            public const string jqueryMin = "ProjectName.Scripts.jquery.min.js";
            public const string jqueryDatepicker = "ProjectName.Scripts.jquery.datepicker.js";
        }
        [ToolboxItemAttribute(false)]
        public class Calendar: WebPart
        {
            protected override void CreateChildControls()
            {
                // Adding Styles (also have to add to AssemblyInfo.cs, as well as changing the Build Action property of the file to embedded resource)
                HtmlLink css = new HtmlLink();
                css.Attributes.Add("type", "text/css");
                css.Attributes.Add("rel", "stylesheet");
                css.Href = Page.ClientScript.GetWebResourceUrl(this.GetType(), Styles.dailog);
                Page.Header.Controls.Add(css);
                HtmlLink css2 = new HtmlLink();
                css2.Attributes.Add("type", "text/css");
                css2.Attributes.Add("rel", "stylesheet");
                css2.Href = Page.ClientScript.GetWebResourceUrl(this.GetType(), Styles.calendar);
                Page.Header.Controls.Add(css2);
                // Adding Scripts (also have to add to AssemblyInfo.cs, as well as changing the Build Action property of the file to embedded resource)
                Page.ClientScript.RegisterClientScriptResource(this.GetType(), Scripts.jqueryMin);
                Page.ClientScript.RegisterClientScriptResource(this.GetType(), Scripts.jqueryDatepicker);
            }
        }
    }
