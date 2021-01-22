    public partial class Form1 : Form {
            private string LoginUrl = "/apilogin/login";
            private string authorizeUrl = "/apilogin/authorize";
            private string doneUrl = "/apilogin/done";
    
            public Form1() {
                InitializeComponent();
                this.Load += new EventHandler(Form1_Load);
            }
    
            void Form1_Load(object sender, EventArgs e) {
                PhotobucketNet.Photobucket pb = new Photobucket("pubkey","privatekey");
                string url = pb.GenerateUserLoginUrl();
                webBrowser1.Url = new Uri(url);
                webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            }
    
            void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
                if (e.Url.AbsolutePath.StartsWith(LoginUrl))
                {
                    webBrowser1.Document.GetElementById("usernameemail").SetAttribute("Value","some username");
                    webBrowser1.Document.GetElementById("password").SetAttribute("Value","some password");
                    webBrowser1.Document.GetElementById("login").InvokeMember("click");
                }
    
                if (e.Url.AbsolutePath.StartsWith(authorizeUrl))
                {
                    webBrowser1.Document.GetElementById("allow").InvokeMember("click");
                }
    
                if (e.Url.AbsolutePath.StartsWith(doneUrl))
                {
                    string token = webBrowser1.Document.GetElementById("oauth_token").GetAttribute("value");
                }
            }
        }
