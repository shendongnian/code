        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
            {   
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = false;
                    return;
                }
            }
