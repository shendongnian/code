     using (var zip = new ZipArchive(outputStream, ZipArchiveMode.Create, leaveOpen: false))
     {
        for (int i = 0; i < msList.Count; i++)
        {
            msList[i].Position = 0;
            var createenter = zip.CreateEntry("123"+i+".jpg", 
            CompressionLevel.Optimal);
            using (var s = createenter.Open())
            {
                msList[i].CopyTo(s);
            }
        }
    }
