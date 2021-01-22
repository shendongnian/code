      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
          this.DoubleBuffered = true;
        }
        Rectangle rec = new Rectangle(0, 0, 0, 0);
    
        protected override void OnPaint(PaintEventArgs e) {
          e.Graphics.FillRectangle(Brushes.Aquamarine, rec);
        }
        protected override void OnMouseDown(MouseEventArgs e) {
          if (e.Button == MouseButtons.Left) {
            rec = new Rectangle(e.X, e.Y, 0, 0);
            Invalidate();
          }
        }
        protected override void OnMouseMove(MouseEventArgs e) {
          if (e.Button == MouseButtons.Left) {
            rec.Width = e.X - rec.X;
            rec.Height = e.Y - rec.Y;
            Invalidate();
          }
        }
      }
