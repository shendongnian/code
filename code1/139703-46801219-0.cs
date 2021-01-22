    /// <summary>
    /// A textbox that supports a watermak hint.
    /// Based on: https://stackoverflow.com/a/15232752
    /// </summary>
    public class WatermarkTextBox : TextBox
    {
        /// <summary>
        /// The text that will be presented as the watermak hint
        /// </summary>
        private string _watermarkText;
        /// <summary>
        /// Gets or Sets the text that will be presented as the watermak hint
        /// </summary>
        public string WatermarkText
        {
            get { return _watermarkText; }
            set { _watermarkText = value; }
        }
        /// <summary>
        /// Whether watermark effect is enabled or not
        /// </summary>
        private bool _watermarkActive;
        /// <summary>
        /// Gets or Sets whether watermark effect is enabled or not
        /// </summary>
        public bool WatermarkActive
        {
            get { return _watermarkActive; }
            set { _watermarkActive = value; }
        }
        /// <summary>
        /// Create a new TextBox that supports watermak hint
        /// </summary>
        public WatermarkTextBox()
        {
            this.WatermarkActive = _watermarkActive;
            this.Text = _watermarkText;
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (this.WatermarkActive)
                CheckWatermark();
        }
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            CheckWatermark();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            CheckWatermark();
        }        
        public void CheckWatermark()
        {
            if ((this.WatermarkActive) && String.IsNullOrWhiteSpace(this.Text))
            {
                ForeColor = Color.Gray;
                this.Text = _watermarkText;
            }
            else if ((this.WatermarkActive) && (!String.IsNullOrWhiteSpace(this.Text)))
            {
                if (this.Text == _watermarkText)
                    this.Text = "";
                ForeColor = Color.Black;
            }
            else
                ForeColor = Color.Black;
        }
    }
