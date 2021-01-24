    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F)
        {
            if (!IsFullScreen)
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                IsFullScreen = true;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                // WindowState = FormWindowState.Normal;   // uncomment this if you also don't 
                                                           // want the form to be maximized.
                IsFullScreen = false;
            }
        }
    }
