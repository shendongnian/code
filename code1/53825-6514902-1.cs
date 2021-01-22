    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        // Create new StreamReader
        StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
        // Get all text from the file
        string str = sr.ReadToEnd();
        // Close the StreamReader
        sr.Close();
    
        // Show the text in the rich textbox rtbMain
        backgroundWorker1.ReportProgress(1, str);
    }
    
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // richTextBox1.Text = e.ProgressPercentage.ToString() + " " + e.UserState.ToString();
        richTextBox1.Text = e.UserState.ToString();
    }
