    private void btnOpenFileDialog_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string fname = openFileDialog.FileName;
            // this is FILENAME
            string FILENAME = "@" + fname;
            // here you use FILENAME instead of this.FILENAME
            txtFile.Text = FILENAME;
        }
    }
    // this is this.FILENAME
    public string FILENAME { get; set; }
    private void btnCalculateMD5_Click(object sender, EventArgs e)
    {
        // uses this.FILENAME
        string results = CalculateMD5(FILENAME);
        richTextBox1.Text = results;
    }
