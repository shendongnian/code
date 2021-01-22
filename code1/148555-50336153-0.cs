    public partial class frmRexcel : Form
    {
        private string mstrClsTitle = "frmRexcel";
        public frmRexcel()
        {
            InitializeComponent();
            this.FormClosing += frmRexcel_FormClosing;
        }
         /// <summary>
        /// Handles the Button Exit Event executed by the Exit Button Click
        /// or Alt + x
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {            
            this.Close();        
        }
        /// <summary>
        /// Handles the Form Closing event
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRexcel_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ---- If windows is shutting down, 
            // ---- I don't want to hold up the process
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            {
                // ---- Ok, Windows is not shutting down so
                // ---- either btnExit or Alt + x or Alt + f4 has been clicked or
                // ---- another form closing event was intiated
                //      *)  Confirm user wants to close the application
                switch (MessageBox.Show(this, 
                                        "Are you sure you want to close the Application?",
                                        mstrClsTitle + ".frmRexcel_FormClosing",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    // ---- *)  if No keep the application alive 
                    //----  *)  else close the application
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }
}
