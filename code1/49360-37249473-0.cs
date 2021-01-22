    /// <summary>
    /// This class provides dynamic size labels, i.e. as the text grows lable width will grow with it. 
    /// </summary>
    public partial class AutoSizeLabel : UserControl
    {
        private string _strText;
        private const int padding = 10;
        public AutoSizeLabel()
        {
            InitializeComponent();
        }
        public override string Text
        {
            get
            {
                return _strText;
            }
            set
            {
                _strText = value;
                Refresh();
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            SizeF size = pe.Graphics.MeasureString(this.Text, this.Font);
            this.Size = new Size((int)size.Width + padding, this.Height);
            if (this.Text.Length > 0)
            {
                pe.Graphics.DrawString(this.Text,
                    this.Font,
                    new SolidBrush(this.ForeColor),
                    (this.ClientSize.Width - size.Width) / 2,
                    (this.ClientSize.Height - size.Height) / 2);
            }
            // Calling the base class OnPaint
            base.OnPaint(pe);
        }
    }
 
