        Form form;
        private void btnDesktop_Click(object sender, EventArgs e)
        {
            if (form == null || desktop.IsDisposed)
            {
                form = new Form();
                form.Show();
            }
            else
            {
                form.WindowState = FormWindowState.Normal;
            }
        }
