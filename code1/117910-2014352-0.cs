    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            contextMenuStrip1.Renderer = new myRenderer();
        }
        class myRenderer : ToolStripProfessionalRenderer {
            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e) {
                // Replace this with your own drawing code...
                base.OnRenderToolStripBackground(e);
            }
        }
    }
