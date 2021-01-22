    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1 {
        public partial class Form1 : Form {
            ToolTip mTip = new ToolTip();
            public Form1() {
                InitializeComponent();
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;
            }
            protected override void OnMouseDown(MouseEventArgs e) {
                mTip.Show("Hi\nthere", this);
            }
        }
    }
