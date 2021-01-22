    public partial class Form1 : Form
    {
        private Rectangle rect;
        private Pen pen = Pens.Black;
        public Form1()
        {
            InitializeComponent();
            rect = new Rectangle(10, 10, Width - 30, Height - 60);
            Click += Form1_Click;
        }
        protected override void OnPaint(PaintEventArgs e) 
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(pen, rect);
        }
        void Form1_Click(object sender, EventArgs e)
        {
            Point cursorPos = this.PointToClient(Cursor.Position);
            if (rect.Contains(cursorPos)) 
            {
                pen = Pens.Red;
            }
            else
            {
                pen = Pens.Black;
            }
            Invalidate();
        }
    }
