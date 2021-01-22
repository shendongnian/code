        path = folderBrowserDialog1.SelectedPath;
    
    
    ImageList imageList1 = new ImageList();
    imageList1.ImageSize = new Size(256, 256);
    imageList1.ColorDepth = ColorDepth.Depth24Bit;
    string[] iconFiles = Directory.GetFiles(path, "*.jpg");
    
    foreach (string iconFile in iconFiles)
    {
       try
       {
          imageList1.Images.Add(Image.FromFile(iconFile));
       }
       catch
       {
             MessageBox("Error","");
       }
    }
    
    this.listView1.View = View.LargeIcon;
    this.listView1.LargeImageList = imageList1;
    
    for (int j = 0; j < imageList1.Images.Count; j++)
    {
        ListViewItem item = new ListViewItem();
    
        item.ImageIndex = j;   
        this.listView1.Items.Add(item);               
    }
