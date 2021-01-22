    using System.ComponentModel;
    using System.Windows.Forms;
    namespace stackoverflow2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.webBrowser1.NewWindow += WebBrowser1_NewWindow;
                this.webBrowser1.Navigated += Wb_Navigated;
                this.webBrowser1.DocumentText=
                 "<html>"+
                 "<head><title>Title</title></head>"+
                 "<body>"+
                 "<a href = 'http://www.google.com' target = 'abc' > test </a>"+
                 "</body>"+
                 "</html>";
            }
            private void WebBrowser1_NewWindow(object sender, CancelEventArgs e)
            {
                e.Cancel = true; //stop normal new window activity
                //get the url you were trying to navigate to
                var url= webBrowser1.Document.ActiveElement.GetAttribute("href");
                //set up the tabs
                TabPage tp = new TabPage();
                var wb = new WebBrowser();
                wb.Navigated += Wb_Navigated;
                wb.Size = this.webBrowser1.Size;
                tp.Controls.Add(wb);
                wb.Navigate(url);
                this.tabControl1.Controls.Add(tp);
                tabControl1.SelectedTab = tp;
            }
            private void Wb_Navigated(object sender, WebBrowserNavigatedEventArgs e)
            {
                tabControl1.SelectedTab.Text = (sender as WebBrowser).DocumentTitle;
            }
        }
    }
