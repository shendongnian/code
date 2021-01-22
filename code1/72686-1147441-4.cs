    public class Input : Form
    {
        public string IPAddress
        {
            get { return txtInput.Text; }
        }
    
        private void btnInput_Click(object sender, EventArgs e)
        {
            //Do some validation for the text in txtInput to be sure the ip is well-formated.
            
            if(ip_well_formated)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
