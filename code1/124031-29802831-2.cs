    using System.Windows.Forms;
    using DotNetBrowser;
    using DotNetBrowser.WinForms;
    
    namespace WinForms.DotNetBrowser
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                BrowserView browserView = new WinFormsBrowserView();
                Controls.Add((Control) browserView);
                browserView.Browser.LoadURL("http://www.youtube.com");
            }
        }
    }
