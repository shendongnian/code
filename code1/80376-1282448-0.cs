      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
        }
    
        private float mZoom = 10;
    
        protected override void OnPaint(PaintEventArgs e) {
          e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
          e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
          Image img = Properties.Resources.SampleImage;
          RectangleF rc = new RectangleF(0, 0, mZoom * img.Width, mZoom * img.Height);
          e.Graphics.DrawImage(img, rc);
        }
      }
