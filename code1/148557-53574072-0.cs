    namespace Test
    {
        public partial class Member : Form
        {
            public Member()
            {
                InitializeComponent();
            }
    
            private bool xClicked = true;
    
            private void btnClose_Click(object sender, EventArgs e)
            {
                xClicked = false;
                Close();
            }
    
            private void Member_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (xClicked)
                {
                    // user click the X
                } 
    			else 
    			{
    				// user click the close button
    			}
            }
        }
    }
