    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                return;
            }
            else
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
            }            
        }
