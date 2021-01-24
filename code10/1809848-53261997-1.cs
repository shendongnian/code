            private void btnOpenPdf_Click(object sender, EventArgs e)
    {
            lblTest.Text = ("@" +lblPdf.Text + ".pdf" );
        try
        {
            MessageBox.Show(lblTest.Text);
            System.Diagnostics.Process.Start(lblTest.Text);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
