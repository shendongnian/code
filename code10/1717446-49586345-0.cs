    private void label1_MouseUp(object sender, MouseEventArgs e)
    {
            if ((e as MouseEventArgs).Button == MouseButtons.Right){
                if(povrniButton.Enabled){
                    povrniButton_Click(sender, null);
                } else {
                    spremeniButton_Click(sender, null);    
                }
            }
    }
