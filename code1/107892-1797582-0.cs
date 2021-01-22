    using System;
    using System.Drawing;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    internal class SampleControl : Control {
        public SampleControl() {
            this.BackColor = Color.Yellow;
        }
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            if (this.DesignMode) this.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override AnchorStyles Anchor {
            get { return base.Anchor; }
            set { base.Anchor = value; }
        }
    }
