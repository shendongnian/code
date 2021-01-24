    private void btnOpenPdf_Click(object sender, EventArgs e)
    {
        try
        {
            System.Diagnostics.Process.Start(lblPdf.Text + ".pdf");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
