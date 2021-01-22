    private void click_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog f = new FolderBrowserDialog();
        
        f.Description = "Please browse to, and select a folder";
        f.RootFolder = "@C:\Name Of Folder You Want Displayed\";
        
        using(f)
        {
            if(f.ShowDialog() == DialogResult.OK)
            {
                // Do something when the user clicks OK or Open.
            }
        }
    }
