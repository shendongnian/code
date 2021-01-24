      using System;
    using System.Windows.Forms;
    
    namespace CTX
    {
        public partial class VerifyForm : Form
        {
            public static IntelOrNo ai = new IntelOrNo(this);//Pass this class as a parameter
    
            public VerifyForm()
            {
                InitializeComponent();
            }
    
            private void btnOkay_Click(object sender, EventArgs e)
            {
                ai.rttam = true;
                this.Close();
            }
    
            private void btnNo_Click(object sender, EventArgs e)
            {
                ai.rttam = false;
                this.Close();
            }
        }
    
        public partial class IntelOrNo : Form
        {
            public bool rttam = false;
            private VerifyForm parent
    
            public IntelOrNo(VerifyForm _parent)
            {
                parent = _parent; //Sets the private parent variable to the initial VerifyForm class, from here you can access the initial VerifyForm class through parent.whatever
                InitializeComponent();
            }
    
            private void btnDoThisWork_Click(object sender, EventArgs e)
            {
                VerifyForm EH = new VerifyForm(); //This creates a NEW instance of the class, not what you want (I think)
    
                parent.StartPosition = FormStartPosition.CenterParent;
                parent.ShowDialog();
    
                if (rttam)
                {
    
                }           
            }
        }
    }
