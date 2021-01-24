    private void LoadImages()
    {
        lv_Images.LargeImageList = new ImageList();
        lv_Images.LargeImageList.ImageSize = new Size(64, 64);
        DirectoryInfo di = new DirectoryInfo(initialDirectory);
        foreach (FileInfo file in di.EnumerateFiles())
        {
            if (isImage(file)) //Simply checks the file extension
            {
                //File.ReadAllBytes will release the handle when the byte array is constructed.
                lv_Images.LargeImageList.Images.Add(file.Name, Image.FromStream(new MemoryStream(File.ReadAllBytes(file.FullName))));
                int index = lv_Images.LargeImageList.Images.IndexOfKey(file.Name);
                lv_Images.Items.Add(file.Name, file.Name, index);
            }
        }
    }
