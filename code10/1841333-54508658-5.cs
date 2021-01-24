    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Gecko;
    using Screen = System.Windows.Forms.Screen;
    public partial class Form1 : Form
    {
        bool IsMaximized = false;
        Rectangle previousPosition = Rectangle.Empty;
        public Form1()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            GeckoPreferences.User["full-screen-api.enabled"] = true;
            GeckoPreferences.Default["full-screen-api.enabled"] = true;
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
            GeckoHtmlElement elm = (GeckoHtmlElement)e.Target.CastToGeckoElement();
            if (elm.ClassName.Contains("fullscreen"))
                this.SetWindowState(FormWindowState.Maximized, false);
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
