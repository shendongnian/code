    // before loading any new image lets release any previously displayed imaged
    if(PictureBox1.Image != null)
    {
         PictureBox1.Image.Dispose();
         PictureBox1.Image = null;
    } 
    // this loads the image, copies it, then closes the handle
    using (var bmpTemp = new Bitmap("image_file_path"))
    {
        PictureBox1.Image = new Bitmap(bmpTemp);
    }
    ...
    // It should be safe to copy the file now, as the handle should be released
    File.Copy(fileName, Path.Combine(@"C:\images\",     newFileName));
