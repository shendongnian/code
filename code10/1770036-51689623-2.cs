    using System;
    using System.Windows.Forms;
    namespace CTX
    {
        public partial class VerifyForm : Form
        {
            public IntelOrNo _parent;
            public VerifyForm(IntelOrNo parent)
            {
                _parent = parent;
                InitializeComponent();
            }
            private void btnOkay_Click(object sender, EventArgs e)
            {
                _parent.rttam = true;
                this.Close();
            }
            private void btnNo_Click(object sender, EventArgs e)
            {
                _parent.rttam = false;
                this.Close();
            }
        }
        public partial class IntelOrNo : Form
        {
            public bool rttam = false;
            public IntelOrNo()
            {
                InitializeComponent();
            }
            private void btnDoThisWork_Click(object sender, EventArgs e)
            {
                VerifyForm EH = new VerifyForm(this);
                EH.StartPosition = FormStartPosition.CenterParent;
                EH.ShowDialog();
                if (rttam)
                {
                }           
            }
        }
    }
