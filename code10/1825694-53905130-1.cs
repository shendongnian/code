    public partial class Form1 : CustomForm
    {
        SolidBrush mybrush;
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height
        public Form1()
        {
            InitializeComponent();
            mybrush = new SolidBrush(this.BackColor);
            // Adds a new shortcut key that will invoke CreateNewForm every time Ctrl+F is pressed
            ShortcutKeys.Add(Keys.Control | Keys.F, CreateNewForm);
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(mybrush, rc);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }
        /// <summary>
        /// Create a new instance of this form
        /// </summary>
        private void CreateNewForm()
        {
            new Form1().Show();
        }
    }
