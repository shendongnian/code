    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            toolStrip1.Renderer = new MyRenderer();
        }
        private class MyRenderer : ToolStripProfessionalRenderer {
            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e) {
                var btn = e.Item as ToolStripButton;
                if (btn != null && btn.CheckOnClick && btn.Checked) {
                    Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                    e.Graphics.FillRectangle(Brushes.Black, bounds);
                }
                else base.OnRenderButtonBackground(e);
            }
        }
    }
