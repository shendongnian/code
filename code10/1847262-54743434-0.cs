      if(string.IsNullOrWhiteSpace(Properties.Settings.Default.path))      
      {
         folderBrowserDialog1.ShowDialog();
         string Source = folderBrowserDialog1.SelectedPath.ToString();
         Properties.Settings.Default.path = Source;
         Properties.Settings.Default.Save();
      }
      Form1 f = new Form1();
      f.Show();
