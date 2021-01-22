    using (MemoryStream iconStream = new MemoryStream())
    {
       icon.Save(iconStream);
       iconStream.Seek(0, SeekOrigin.Begin);
    
       this.TargetWindow.Icon = System.Windows.Media.Imaging.BitmapFrame.Create(iconStream);
    }
