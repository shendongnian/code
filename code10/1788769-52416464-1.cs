    if(folderBrDlg.ShowDialog()==DialogResult.Ok)
    {
        int i = 0;
        foreach(string fname in System.IO.Directory.GetFiles())
        {
    
             Button btn = new Button
             { 
                   Text = fname.Split('\\').LastOrDefault(),
                   Location = new Point(10, 10 + i++ * 30),   //sample x,y
                   Size = new Size(100,20),
                   Tag = fname,   //For having the file location
                   ....
             };
             btn.Click += (s, e) =>
             {
                  string fileToPlay = (string)((Button)s).Tag; 
                  //now you only have to play it.
             }
             this.Controls.Add(btn);
        }
    }
