    public System.Windows.Media.Imaging.BitmapImage QuestionIcon
    {
        get
        {
            using (MemoryStream ms = new MemoryStream())
            {
                System.Drawing.Bitmap dImg = SystemIcons.ToBitmap();
                dImg.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Position = 0;
                var bImg = new System.Windows.Media.Imaging.BitmapImage();
                bImg.BeginInit();
                bImg.StreamSource = ms;
                bImg.EndInit();
                return bImg;
            }
        }
    }
