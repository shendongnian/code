    private void LoadFile()
    {
        try
        {
            using(FileStream fileStream = new FileStream(
                "logs/myapp.log",
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite))
            {
                using(StreamReader streamReader = new StreamReader(fileStream))
                {
                    this.textBoxLogs.Text = streamReader.ReadToEnd();
                }
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show("Error loading log file: " + ex.Message);
        }
    } 
