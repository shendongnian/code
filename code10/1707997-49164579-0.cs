        private void btnSend_Click(object sender, EventArgs e)
        {   
             lstMsg.BackColor = Color.AliceBlue;
             lstMsg.ForeColor = Color.Blue;
             lstMsg.Items.Add("You:" + txtMsg.Text);
             lstMsg.RightToLeft = RightToLeft.Yes; //Check this
        }
