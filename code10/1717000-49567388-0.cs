    FileInfo file = new FileInfo(FilePath.Text);
    FileStream f1 = new FileStream(FilePath.Text, FileMode.Open, 
    FileAccess.Read, FileShare.Read);
    byte[] BytesOfPic = new byte[Convert.ToInt32(file.Length)];
    f1.Read(BytesOfPic, 0, Convert.ToInt32(file.Length));
    
    using (MemoryStream mStream = new MemoryStream())
    {
        mStream.Write(BytesOfPic, 0, BytesOfPic.Length);
        mStream.Seek(0, SeekOrigin.Begin);
        Bitmap bm = new Bitmap(mStream);
    
        // ImageBox is name of a PictureBox
        ImageBox.image = bm;
    }
