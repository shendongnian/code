    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Gecko;
    using Screen = System.Windows.Forms.Screen;
    public partial class Form1 : Form
    {
        bool IsMaximized = false;
        bool TheaterClicked = false;
        Rectangle previousPosition = Rectangle.Empty;
        string UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:65.0) Gecko/20100101 Firefox/65.0";
        public Form1()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            GeckoPreferences.User["full-screen-api.enabled"] = true;
            GeckoPreferences.Default["full-screen-api.enabled"] = true;
            GeckoPreferences.User["general.useragent.override"] = UserAgent;
            GeckoPreferences.Default["general.useragent.override"] = UserAgent;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            previousPosition = this.Bounds;
            this.geckoWebBrowser1.Navigate("[Some URL]");
            this.geckoWebBrowser1.GetDocShellAttribute().SetFullscreenAllowed(true);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) { 
                SetWindowState(this.WindowState, false);
            }
            else if (!this.IsMaximized) { 
                this.previousPosition = this.Bounds;
            }
        }
        private void geckoWebBrowser1_DomMouseDown(object sender, DomMouseEventArgs e)
        {
            if (geckoWebBrowser1.Url.Host.Contains("youtu"))
            {
                GeckoHtmlElement elm = (GeckoHtmlElement)e.Target.CastToGeckoElement();
                switch (elm.ClassName)
                {
                    case "ytp-fullscreen-button ytp-button":
                        if (this.geckoWebBrowser1.Document.GetElementsByClassName("ytp-size-button ytp-button").FirstOrDefault() is GeckoHtmlElement theater)
                        {
                            if (this.TheaterClicked == false) {
                                theater.Click();
                                this.TheaterClicked = true;
                            }
                        }
                        break;
                    case "ytp-size-button ytp-button":
                        this.TheaterClicked = !this.TheaterClicked;
                        break;
                    default:
                        break;
                }
            }
        }
        private void SetWindowState(FormWindowState state, bool setSize)
        {
            if (state == FormWindowState.Maximized) {
                this.IsMaximized = true;
                if (setSize) this.previousPosition = this.Bounds;
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Location = Point.Empty;
                this.Size = Screen.FromHandle(this.Handle).Bounds.Size;
            }
            else {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Bounds = this.previousPosition;
                this.IsMaximized = false;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            base.ProcessCmdKey(ref msg, keyData);
            if (keyData == Keys.F11) {
                SetWindowState(this.IsMaximized ? FormWindowState.Normal : FormWindowState.Maximized, true);
                return true;
            }
            else {
                return false;
            }
        }
    }
