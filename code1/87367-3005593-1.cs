    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Text.RegularExpressions;
    
    namespace MMSoftware.TheMMSoft.UI
    {
        public class BasePage : System.Web.UI.Page
        {
            private string _canonical;
            // Constructor
            public BasePage()
            {
                Init += new EventHandler(BasePage_Init);
            }
    
            // Whenever a page that uses this base class is initialized
            // add link canonical if available
            void BasePage_Init(object sender, EventArgs e)
            {             
                if (!String.IsNullOrEmpty(Link_Canonical))
                {
                    HtmlLink link = new HtmlLink();
                    link.Href = Link_Canonical;
                    link.Attributes.Add(HtmlTextWriterAttribute.Rel.ToString().ToLower(), "canonical");
                    link.Attributes.Add(HtmlTextWriterAttribute.Type.ToString().ToLower(), "");
                    link.Attributes.Add("media", "");
                    Header.Controls.Add(link);
                }
            }
                
            /// <summary>
            /// Gets or sets the Link Canonical tag for the page
            /// </summary>
            public string Link_Canonical
            {
                get
                {
                    return _canonical;
                }
                set
                {
                    _canonical = value;
                }
            }                   
        }
    }
