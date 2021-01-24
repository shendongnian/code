    StorageFolder cover = await komik.GetFolderAsync("cover");
    List<StorageFile> deletedFileList = new List<StorageFile>();
    foreach (StorageFile file in sortedfiles)
    {
        bool bukuada = true;
        Buku buku = new Buku();
        buku.Judul = file.DisplayName.ToString();
        BasicProperties pro = await file.GetBasicPropertiesAsync();
        if (pro.Size != 0)
        {
            StorageFile thumbFile = file;
            try
            {
                thumbFile = await cover.GetFileAsync(file.DisplayName.ToString() + ".jpg");
                BitmapImage bi = new BitmapImage();
                bi.SetSource(await thumbFile.OpenAsync(FileAccessMode.Read));
                buku.Cover = bi;
    
                datasource.Add(buku);
                loading.IsActive = false;           
            }
            catch
            {
    
            }
        }
        else
        {
            deletedFileList.Add(file);
        }
    }
    
    // display the data source.
     this.itemGridView.ItemsSource = datasource;
    
     // delete the file
        foreach(var temp in deletedFileList)
        {
            try
            {
                await deletedFileList.DeleteAsync();
            }
            catch(IOException)
            {
                
            }
        }
