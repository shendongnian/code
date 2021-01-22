    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;
    
    namespace WindowsFormsApplication1 {
      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
          panel1.Paint += panel1_Paint;
        }
        VisualStyleRenderer renderer = new VisualStyleRenderer(VisualStyleElement.Button.PushButton.Normal);
        private void panel1_Paint(object sender, PaintEventArgs e) {
          renderer.DrawEdge(e.Graphics, panel1.ClientRectangle,
            Edges.Bottom | Edges.Left | Edges.Right | Edges.Top,
            EdgeStyle.Raised, EdgeEffects.Flat);
        }
      }
    }
