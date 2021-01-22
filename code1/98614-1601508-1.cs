    public partial class ThextBox : UserControl
    {
        private TextBox _TextBox;
        private int _BorderWidth = 1;
        [Browsable(true)]
        [DesignerSerializationVisibility
            (DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return _TextBox.Text;
            }
            set
            {
                _TextBox.Text = value;
            }
        }
        [DesignerSerializationVisibility
            (DesignerSerializationVisibility.Visible)]
        public bool Multiline
        {
            get
            {
                return _TextBox.Multiline;
            }
            set
            {
                _TextBox.Multiline = value;
                ResizeMe();
            }
        }
        [DesignerSerializationVisibility
            (DesignerSerializationVisibility.Visible)]
        public bool UseSystemPasswordChar
        {
            get
            {
                return _TextBox.UseSystemPasswordChar;
            }
            set
            {
                _TextBox.UseSystemPasswordChar = value;
            }
        }
        [DesignerSerializationVisibility
            (DesignerSerializationVisibility.Visible)]
        public char PasswordChar
        {
            get
            {
                return _TextBox.PasswordChar;
            }
            set
            {
                _TextBox.PasswordChar = value;
            }
        }
        [DesignerSerializationVisibility
            (DesignerSerializationVisibility.Visible)]
        public int BorderWidth
        {
            get
            {
                return _BorderWidth;
            }
            set
            {
                _BorderWidth = value;
                ResizeMe();
            }
        }
               
        public ThextBox()
        {
            InitializeComponent();
            this.BackColor = SystemColors.WindowFrame;
            _TextBox = new TextBox();
            _TextBox.Multiline = false;
            _TextBox.BorderStyle = BorderStyle.None;
            this.Controls.Add(_TextBox);
            ResizeMe();
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            ResizeMe();
        }
        private void ResizeMe()
        {
            if (this.Multiline)
            {
                _TextBox.Height = this.Height - (2 * _BorderWidth);
            }
            else
            {
                this.Height = _TextBox.Height + (2 * _BorderWidth);
            }
            _TextBox.Width = this.Width - (2 * _BorderWidth);
            _TextBox.Location = new Point(_BorderWidth, _BorderWidth);
        }
        private void ThextBox_Resize(object sender, EventArgs e)
        {
            ResizeMe();
        }
    }
