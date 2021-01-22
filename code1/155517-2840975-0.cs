    var video = new MediaItem(filePath);
    using (var bitmap = video.MainMediaFile.GetThumbnail(
        new TimeSpan(0, 0, 5), 
        new System.Drawing.Size(640, 480)))
    {
        // do something with the bitmap like:
        bitmap.Save("thumb1.jpg");
    }
