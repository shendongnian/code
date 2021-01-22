    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web;
    using System.Web.UI;
    using System.Linq;
    using TTC.iTropics.Utilities;
    
    namespace WebApplication1
    {
        [DefaultProperty("Stylesheets")]
        [ParseChildren(true, "Stylesheets")]
        public class CssControl : LiteralControl
        {
            [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
            public List<Stylesheet> Stylesheets { get; set; }
    
            public CssControl()
            {
                Stylesheets = new List<Stylesheet>();
            }
    
            protected override void Render(HtmlTextWriter output)
            {
                if (HttpContext.Current.IsDebuggingEnabled)
                {
                    const string format = "<link rel=\"Stylesheet\" href=\"stylesheets/{0}\"></link>";
                    foreach (Stylesheet sheet in Stylesheets)
                        output.Write(format, sheet.File);
                }
                else
                {
                    const string format = "<link type=\"text/css\" rel=\"Stylesheet\" href=\"stylesheets/CssHandler.ashx?cssfiles={0}&version={1}\"/>";
                    IEnumerable<string> stylesheetsArray = Stylesheets.Select(s => s.File);
                    string stylesheets = String.Join(",", stylesheetsArray.ToArray());
                    string version = "1.00" //your version number
    
                    output.Write(format, stylesheets, version);
                }
    
            }
        }
        public class Stylesheet
        {
            public string File { get; set; }
        }
    }
