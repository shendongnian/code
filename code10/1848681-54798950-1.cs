    private string[] ShowMergeDlg(string[] files)
    {
        /*
        if (this.InvokeRequired)
        {
            this.BeginInvoke(new Action(() =>
            {
                MergeDlg md = new MergeDlg();
                md.Files = (string[])files;
                if (md.ShowDialog(this) == DialogResult.OK)
                    files = md.Files;
            }
            ));
        }
        else
        */
        {
            MergeDlg md = new MergeDlg();
            md.Files = (string[])files;
            if (md.ShowDialog(this) == DialogResult.OK)
                files = md.Files;
        }
    
        return files;
    }
