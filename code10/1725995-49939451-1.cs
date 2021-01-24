        ImageList imageList = new ImageList();
        prodview.LargeImageList = imageList;
        while(i <20)
        {
            var json = c.DownloadString(url + (i + 1).ToString());
            var image = c.DownloadData(urlicon + (i + 1).ToString());
        
            var dataDict = JsonConvert.DeserializeObject<List<Data>>(json);
        
            ListViewItem item = new ListViewItem();
    // not sure what you were trying to do here as it would always end up with the last name..    
    //        foreach (var data in dataDict)
    //        item.Text = data.name; 
            item.Text = "item "+i; // giving it a name
        
            imageList.ImageSize = new Size(100, 100);
            imageList.Images.Add(i.ToString(), new Bitmap(new MemoryStream(image)));
        
            item.ImageIndex = i;
            prodview.Items.Add(item);     
        
            i++;
        
        }
