    using System;
    using System.Windows.Forms;
    
    class MyFlowLayoutPanel : FlowLayoutPanel {
        public MyFlowLayoutPanel() {
            this.DoubleBuffered = true;
        }
        protected override void OnScroll(ScrollEventArgs se) {
            this.Invalidate();
            base.OnScroll(se);
        }
    }
