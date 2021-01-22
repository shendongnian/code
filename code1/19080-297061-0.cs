    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;
    using System.Reflection;
    
    namespace WindowsFormsApplication1 {
      public partial class Form1 : Form {
        VisualStyleElement pulseOverlay;
        VisualStyleElement moveOverlay;
        VisualStyleRenderer pulseRenderer;
        VisualStyleRenderer moveRenderer;
        Timer animator = new Timer();
        public Form1() {
          InitializeComponent();
          ConstructorInfo ci = typeof(VisualStyleElement).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
            null, new Type[] { typeof(string), typeof(int), typeof(int) }, null);
          pulseOverlay = (VisualStyleElement)ci.Invoke(new object[] { "PROGRESS", 7, 0 });
          moveOverlay = (VisualStyleElement)ci.Invoke(new object[] { "PROGRESS", 8, 0 });
          pulseRenderer = new VisualStyleRenderer(pulseOverlay);
          moveRenderer = new VisualStyleRenderer(moveOverlay);
          animator.Interval = 20;
          animator.Tick += new EventHandler(animator_Tick);
          animator.Enabled = true;
          this.DoubleBuffered = true;
        }
        void animator_Tick(object sender, EventArgs e) {
          Invalidate();
        }
    
        int xpos;
        protected override void OnPaint(PaintEventArgs e) {
          Rectangle rc = new Rectangle(10, 10, 100, 20);
          ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rc);
          rc = new Rectangle(10, 10, 50, 20);
          ProgressBarRenderer.DrawHorizontalChunks(e.Graphics, rc);
          xpos += 3;
          if (xpos >= 30) xpos = -150;  // Note: intentionally too far left
          rc = new Rectangle(xpos, 10, 50, 20);
          pulseRenderer.DrawBackground(e.Graphics, rc);
          moveRenderer.DrawBackground(e.Graphics, rc);
        }
      }
    
    }
