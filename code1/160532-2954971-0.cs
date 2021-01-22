    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            /* 
                  ... misc housekeeping ... 
            */
    
            private void OnLeave(object sender, EventArgs e)
            {
                lblMsg.Text = "left field 1";
            }
    
            private void OnLeave2(object sender, EventArgs e)
            {
                lblMsg.Text = "left field 2";
            }
        }
    }
