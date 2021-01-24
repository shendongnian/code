    [ComVisible(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var txt =
            @"<html>" +
            @"<body>" +
            @"<a href=""#"" " +
                @"onclick=""window.external.Method1(this, 'Hello');"">" +
                @"Click here.</a>" +
            @"</body>" +
            @"</html>";
            webBrowser1.ObjectForScripting = this;
            webBrowser2.ObjectForScripting = this;
            webBrowser1.DocumentText = txt;
            webBrowser2.DocumentText = txt;
            webBrowser1.Document.Window.Name = webBrowser1.Name;
            webBrowser2.Document.Window.Name = webBrowser2.Name;
        }
        public void Method1(object sender, string s)
        {
            //sender is the anchor element
            dynamic window = ((dynamic)((dynamic)sender).document).defaultView;
            var windowName = window.Name;
            var control = this.Controls.Find(windowName, true);
            MessageBox.Show(s);
        }
    }
