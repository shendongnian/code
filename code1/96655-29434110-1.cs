        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;//optional, better target a panel or specific controls
                this.UseWaitCursor = true;//from the Form/Window instance
                Application.DoEvents();//messages pumped to update controls
                //execute a lengthy blocking operation here, 
                //bla bla ....
            }
            finally
            {
                this.Enabled = true;//optional
                this.UseWaitCursor = false;
            }
        }
