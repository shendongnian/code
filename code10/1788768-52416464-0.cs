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
             this.Controls.Add(btn);
        }
    }
