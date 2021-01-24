    if(e.newState == 8)
    {
       if(listBox1.Items.Count > 1)
       {
             if (listBox1.SelectedIndex != listBox1.Items.Count - 1)
             {
                   listBox1.SelectedIndex++;
                   axWindowsMediaPlayer1.URL = SongsNPaths[listBox1.SelectedItem.ToString()];
    
                   this.BeginInvoke(new Action(() => {
                    this.axWindowsMediaPlayer1.URL = newFilePath;
                }));
             }
       }
    }
