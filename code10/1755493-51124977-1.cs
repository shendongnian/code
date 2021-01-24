    private void btnOpenFileDialog_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            FileName = openFileDialog.FileName;
            txtFile.Text = FileName;
        }
    }
    // this is this.FileName
    public string FileName { get; set; }
    private void btnCalculateMD5_Click(object sender, EventArgs e)
    {
        // uses this.FileName
        string results = CalculateMD5(FileName);
        richTextBox1.Text = results;
    }
