    using (var dlg = new System.Windows.Forms.OpenFileDialog())
    {
        dlg.Title = "Select database file to use";
        dlg.Filter = ".mdf|Database Files";
        dlg.CheckFileExists = true;
        if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            Properties.Settings.Default.DbFile = dlg.FileName;
            Properties.Settings.Default.Save();
        }
    }
