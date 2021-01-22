      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
        }
        private const int SnapDist = 100;
        private bool DoSnap(int pos, int edge) {
          int delta = pos - edge;
          return delta > 0 && delta <= SnapDist;
        }
        protected override void  OnResizeEnd(EventArgs e) {
          base.OnResizeEnd(e);
          Screen scn = Screen.FromPoint(this.Location);
          if (DoSnap(this.Left, scn.WorkingArea.Left)) this.Left= scn.WorkingArea.Left;
          if (DoSnap(this.Top, scn.WorkingArea.Top)) this.Top = scn.WorkingArea.Top;
          if (DoSnap(scn.WorkingArea.Right, this.Right)) this.Left = scn.WorkingArea.Right - this.Width;
          if (DoSnap(scn.WorkingArea.Bottom, this.Bottom)) this.Top = scn.WorkingArea.Bottom - this.Height;
        }
      }
