    void fsw_Changed(object sender, FileSystemEventArgs e)
    {
      updateLabelFromTextFile();
    }
    private void updateLabelFromTextFile()
    {
      var fs = File.OpenText(@"c:\temp\yourfile.txt");
      string sContent = fs.ReadToEnd();
      fs.Close();
      fs.Dispose();
      if (label1.InvokeRequired)
      {
        MethodInvoker mi = delegate { label1.Text = sContent; };
        this.BeginInvoke(mi);
      }
      else
        label1.Text = sContent;
    }
