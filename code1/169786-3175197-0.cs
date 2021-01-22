    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.txtZoom.Text = "1";
                this.txtZoom.KeyDown += new KeyEventHandler(txtZoom_KeyDown);
                this.txtZoom_KeyDown(txtZoom, new KeyEventArgs(Keys.Enter));
            }
    
            void txtZoom_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyData == Keys.Enter)
                {
                    this.Zoom = int.Parse(txtZoom.Text);
                    this.Invalidate();
                }
            }
    
            public int Zoom { get; set; }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(new Rectangle(10, 10, 100, 100));
    
                Matrix m = new Matrix();
                m.Scale(Zoom, Zoom);
    
                path.Transform(m);
                this.AutoScrollMinSize = Size.Round(path.GetBounds().Size);
    
                e.Graphics.FillPath(Brushes.Black, path);
            }
        }
    }
