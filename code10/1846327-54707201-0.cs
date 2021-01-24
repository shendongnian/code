    listView1.View = View.LargeIcon;
    ImageList iList = new ImageList();
    iList.ImageSize = new Size(128, 128);
    iList.ColorDepth = ColorDepth.Depth32Bit;
    iList.Images.Add(Properties.Resources.x64_Clear_icon); 
    listView1.LargeImageList = iList;
