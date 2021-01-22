    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    
    namespace MySite
    {
        /// <summary>
        /// Base class with properties for meta tags for content pages
        /// http://www.codeproject.com/KB/aspnet/PageTags.aspx
        /// http://weblogs.asp.net/scottgu/archive/2005/08/02/421405.aspx
        /// </summary>
        public partial class BasePage : System.Web.UI.Page
        {
            private string keywords;
            private string description;
    
    
            /// <SUMMARY>
            /// Gets or sets the Meta Keywords tag for the page
            /// </SUMMARY>
            public string Meta_Keywords
            {
                get
                {
                    return keywords;
                }
                set
                {
                    // Strip out any excessive white-space, newlines and linefeeds
                    keywords = Regex.Replace(value, "\\s+", " ");
                }
            }
    
            /// <SUMMARY>
            /// Gets or sets the Meta Description tag for the page
            /// </SUMMARY>
            public string Meta_Description
            {
                get
                {
                    return description;
                }
                set
                {
                    // Strip out any excessive white-space, newlines and linefeeds
                    description = Regex.Replace(value, "\\s+", " ");
                }
            }
    
    
            // Constructor
            // Add an event handler to Init event for the control
            // so we can execute code when a server control (page)
            // that inherits from this base class is initialized.
            public BasePage()
            {
                Init += new EventHandler(BasePage_Init); 
            }
    
    
            // Whenever a page that uses this base class is initialized,
            // add meta keywords and descriptions if available
            void BasePage_Init(object sender, EventArgs e)
            {
                if (!String.IsNullOrEmpty(Meta_Keywords))
                {
                    HtmlMeta tag = new HtmlMeta();
                    tag.Name = "keywords";
                    tag.Content = Meta_Keywords;
                    Header.Controls.Add(tag);
                }
    
                if (!String.IsNullOrEmpty(Meta_Description))
                {
                    HtmlMeta tag = new HtmlMeta();
                    tag.Name = "description";
                    tag.Content = Meta_Description;
                    Header.Controls.Add(tag);
                }
            }
        }
    }
