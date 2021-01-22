    public partial class ModalLoadingUI : Form
    {
        #region Constants
        private readonly Color BackgroundFadeColor = Color.FromArgb(50, Color.Black);
        #endregion
        #region Constructors
        public ModalLoadingUI()
        {
            InitializeComponent();
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or Sets the main form that will be used as a background canvas for the loading form.
        /// </summary>
        public Form BackgroundForm { get; set; }
        /// <summary>
        /// Gets or Sets the text to displayed as the progress text.
        /// </summary>
        public string Title
        { 
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }
        /// <summary>
        /// Gets or Sets the value of the progress bar.
        /// </summary>
        public int? Progress
        {
            get
            {
                if (progressBar1.Style == ProgressBarStyle.Marquee)
                {
                    return null;
                }
                else
                {
                    return progressBar1.Value;
                }
            }
            set
            {
                if (value == null)
                {
                    progressBar1.Style = ProgressBarStyle.Marquee;
                    progressBar1.Value = 100;
                    label2.Visible = false;
                }
                else
                {
                    progressBar1.Style = ProgressBarStyle.Continuous;
                    progressBar1.Value = value.Value;
                    label2.Text = string.Format("{0}%", value);
                    label2.Visible = true;
                }
            }
        }
        /// <summary>
        /// Gets or Sets a value to indicate if the background form should be faded out.
        /// </summary>
        public bool UseFadedBackground { get; set; }
        /// <summary>
        /// Gets or Sets a value to indicate if the splash box is to be displayed.
        /// </summary>
        public bool UseSplashBox
        {
            get
            {
                return picShadow.Visible;
            }
            set
            {
                if (value == true)
                {
                    picShadow.Visible = true;
                    panel1.Visible = true;
                }
                else
                {
                    picShadow.Visible = false;
                    panel1.Visible = false;
                }
            }
        }
        #endregion
        #region Base Events
        private void ModalLoadingUI_Load(object sender, EventArgs e)
        {
            if (this.BackgroundForm != null)
            {
                this.Location = this.BackgroundForm.Location;
            }
        }
        private void ModalLoadingUI_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                if (this.BackgroundForm != null)
                {
                    this.Location = this.BackgroundForm.Location;
                }
            }
            if (System.Diagnostics.Debugger.IsAttached == true)
            {
                this.TopMost = false;
            }
            else
            {
                this.TopMost = true;
            }
        }
        private void ModalLoadingUI_Shown(object sender, EventArgs e)
        {
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Paints the background form as the background of this form, if one is defined.
        /// </summary>
        public void CaptureBackgroundForm()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(CaptureBackgroundForm));
                return;
            }
            if (this.BackgroundForm == null)
            {
                return;
            }
            
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmpScreenshot);
            try
            {
                // COPY BACKGROUND
                int x = this.BackgroundForm.Left;
                int y = this.BackgroundForm.Top;
                var size = this.BackgroundForm.Size;
                g.CopyFromScreen(x, y, 0, 0, size, CopyPixelOperation.SourceCopy);
                // FADE IF DESIRED
                if (this.UseFadedBackground == true)
                {
                    var rect = new Rectangle(0, 0, size.Width, size.Height);
                    g.FillRectangle(new SolidBrush(BackgroundFadeColor), rect);
                }
                // PAINT SPLASH BOX SHADOW IF DESIRED
                if(this.UseSplashBox == true)
                {
                    PaintPanelShadow(g);
                }
            }
            catch (Exception e)
            {
                g.Clear(Color.White);
            }
            this.BackgroundImage = bmpScreenshot;
        }
        /// <summary>
        /// Paints a shadow around the panel, if one is defined.
        /// </summary>
        /// <param name="g">The graphics object to paint into</param>
        private void PaintPanelShadow(Graphics g)
        {
            var shadowImage = picShadow.Image;
            var x = panel1.Left + (panel1.Width / 2) - (shadowImage.Width / 2);
            var y = panel1.Top + (panel1.Height / 2) - (shadowImage.Height / 2);
            g.DrawImage(shadowImage, x, y, shadowImage.Width, shadowImage.Height);
        }
        #endregion
    }
