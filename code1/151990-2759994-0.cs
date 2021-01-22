    public partial class CustomControl1 : Control
    {
        public CustomControl1()
        {
            InitializeComponent();
        }
    
        protected override void OnGotFocus(EventArgs e)
        {
            this.BackColor = Color.Black;
            base.OnGotFocus(e);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
