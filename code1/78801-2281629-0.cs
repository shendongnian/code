    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace SomeNameSpace
    {
        public class WebForm : Form
        {
            public WebBrowser WebBrowser { get; set; }
    
            public WebForm()
            {
                WebBrowser = new WebBrowser();
            }
        }
    }
